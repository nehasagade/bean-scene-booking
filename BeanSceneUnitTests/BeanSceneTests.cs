


using System.Collections.Generic;

namespace BeanSceneUnitTests
{
    [TestClass]
    public class BeanSceneTests
    {
        [TestMethod]
        public async Task BookingIndexTest()
        {
            // Arrange
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
            optionsBuilder.UseInMemoryDatabase("BeanSceneDB");
            var _dbContext = new ApplicationDbContext(optionsBuilder.Options);
            Booking booking = new Booking
            {
                Id = 1,
                Date = DateTime.Now.Date,
                StartTime = new TimeSpan(18, 0, 0),
                NumOfGuests = 4,
                RequiredTables = 1,
                Status = Booking.StatusEnum.Pending,
                Source = Booking.SourceEnum.Email,
                FirstName = "Frodo",
                LastName = "Baggins",
                Email = "frodo@baggins.com.au",
                Phone = "030394985"
            };
            Booking booking2 = new Booking
            {
                Id = 2,
                Date = DateTime.Now.Date,
                StartTime = new TimeSpan(18, 0, 0),
                NumOfGuests = 4,
                RequiredTables = 1,
                Status = Booking.StatusEnum.Pending,
                Source = Booking.SourceEnum.Email,
                FirstName = "Moon",
                LastName = "Jade",
                Email = "moon@indigo.com.au",
                Phone = "090303030"
            };
            
            _dbContext.Add(booking);
            _dbContext.Add(booking2);
            _dbContext.SaveChanges();
            
            // _dbContext.Database.EnsureCreated();
            var controller = new BookingController(_dbContext);

            // Act
            var result = await controller.Index() as ViewResult;
            var model = result.ViewData.Model;

            // Assert that the Index data contains both bookings.
            CollectionAssert.Contains((System.Collections.ICollection)model, booking);
            CollectionAssert.Contains((System.Collections.ICollection)model, booking2);
            Assert.IsInstanceOfType(model, typeof(IEnumerable<Booking>));

        }

        [TestMethod]
        public async Task CreateBookingSuccess()
        {
            // Arrange
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
            optionsBuilder.UseInMemoryDatabase("BeanSceneDB");
            var _dbContext = new ApplicationDbContext(optionsBuilder.Options);

            BookingViewModel bookingVM = new BookingViewModel
            {
                Id = 1,
                Date = DateTime.Now.Date,
                StartTime = new TimeSpan(18, 0, 0),
                NumOfGuests = 4,
                RequiredTables = 1,
                Status = BookingViewModel.StatusEnum.Pending,
                Source = BookingViewModel.SourceEnum.Email,
                FirstName = "Frodo",
                LastName = "Baggins",
                Email = "frodo@baggins.com.au",
                Phone = "030394985"
            };

            var controller = new BookingController(_dbContext);

            // Act 
            var result = await controller.Create(bookingVM) as ViewResult;
            var model = result.ViewData.Model;

            // Assert
            Assert.AreEqual(bookingVM, model);

        }

        [TestMethod]
        public async Task CreateBookingFail()
        {
            // Arrange
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
            optionsBuilder.UseInMemoryDatabase("BeanSceneDB");
            var _dbContext = new ApplicationDbContext(optionsBuilder.Options);

            BookingViewModel bookingVM = new BookingViewModel
            {
                Id = 1,
                Date = new DateTime(2022, 11, 20), // Date is in the past - should throw error
                StartTime = new TimeSpan(18, 0, 0),
                NumOfGuests = 4,
                RequiredTables = 1,
                Status = BookingViewModel.StatusEnum.Pending,
                Source = BookingViewModel.SourceEnum.Email,
                FirstName = "Frodo",
                LastName = "Baggins",
                Email = "frodo@baggins.com.au",
                Phone = "030394985"
            };
            var controller = new BookingController(_dbContext);

            // Act
            var result = await controller.Create(bookingVM) as ViewResult;
            // The Create method will add an error to the ModelState, so by counting the number of errors, we know that the correct path was taken.
            int modelError = result.ViewData.ModelState.ErrorCount;

            // Assert
            Assert.AreEqual(1, modelError);

        }
    }
}