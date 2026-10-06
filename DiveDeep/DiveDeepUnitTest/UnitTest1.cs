using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.EntityFrameworkCore;
using DiveDeep.Models;
using DiveDeep.Persistence;
using DiveDeep.Service;
using DiveDeep.Data;

namespace DiveDeepUnitTest
{
    [TestClass]
    public class AdminCreateEquipmentTest
    {
        private DiveDeepContext _context = null!;
        private EquipmentRepository _equipmentRepository = null!;
        private BookingRepository _bookingRepository = null!;
        private CartItemRepository _cartItemRepository = null!;
        private BookingEquipmentSizeRepository _bookingEquipmentSizeRepository = null!;

        [TestInitialize]
        public void Setup()
        {
            var options = new DbContextOptionsBuilder<DiveDeepContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase").Options;

            _context = new DiveDeepContext(options);

            _equipmentRepository = new EquipmentRepository(_context);
            _bookingEquipmentSizeRepository = new BookingEquipmentSizeRepository(_context);
            _bookingRepository = new BookingRepository(_context, _bookingEquipmentSizeRepository);
            _cartItemRepository = new CartItemRepository(_context);
        }

        [TestCleanup]
        public void Cleanup()
        {
            _context.Database.EnsureDeleted();
            _context.Dispose();
        }

        [TestMethod]
        public async Task AdminCanAddEquipment()
        {
            // Arrange
            var testEquipment = new Equipment
            {
                Title = "Test Regulator",
                Description = "Test description",
                Category = "Regulator",
                Price = 1000,
                Amount = 5,
                Image = "test-regulator.jpg",
                CartItems = new List<CartItem>()
            };

            Console.WriteLine($"Creating equipment: {testEquipment.Title}");

            var adminService = new AdminService(
                _equipmentRepository,
                _bookingRepository,
                _cartItemRepository
            );

            // Act
            var result = await adminService.CreateEquipmentAsync(testEquipment);

            Console.WriteLine($"Equipment created with ID: {result.EquipmentId}");
            Console.WriteLine($"Equipment Title: {result.Title}");
            Console.WriteLine($"Equipment Category: {result.Category}");
            Console.WriteLine($"Equipment Price: {result.Price}");

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("Test Regulator", result.Title);
            Assert.AreEqual("Regulator", result.Category);
            Assert.AreEqual(1000, result.Price);

            // Verify it saved to DB
            var savedEquipment = await _context.Equipments.FirstOrDefaultAsync(e => e.Title == "Test Regulator");
            Console.WriteLine($"Saved equipment found in DB: {savedEquipment != null}");
            Assert.IsNotNull(savedEquipment);
            Assert.AreEqual("Test Regulator", savedEquipment.Title);
            Assert.AreEqual("Regulator", savedEquipment.Category);
        }

        [TestMethod]
        public async Task VerifyDatabasePersistence()
        {
            // Arrange
            var testEquipment = new Equipment
            {
                Title = "Test Tank",
                Description = "Test tank description",
                Category = "Tanks",
                Price = 500,
                Amount = 10,
                Image = "test-tank.jpg",
                CartItems = new List<CartItem>()
            };

            Console.WriteLine($"Creating equipment: {testEquipment.Title}");

            var adminService = new AdminService(
                _equipmentRepository,
                _bookingRepository,
                _cartItemRepository
            );

            // Act
            var result = await adminService.CreateEquipmentAsync(testEquipment);

            Console.WriteLine($"Equipment created successfully");

            // Assert and verfy it saved in the DB
            var allEquipment = await _context.Equipments.ToListAsync();
            Console.WriteLine($"Total equipment in DB: {allEquipment.Count}");
            Console.WriteLine($"First equipment Title: {allEquipment[0].Title}");
            Console.WriteLine($"First equipment Category: {allEquipment[0].Category}");
            Console.WriteLine($"First equipment Price: {allEquipment[0].Price}");

            Assert.AreEqual(1, allEquipment.Count);
            Assert.AreEqual("Test Tank", allEquipment[0].Title);
            Assert.AreEqual("Tanks", allEquipment[0].Category);
            Assert.AreEqual(500, allEquipment[0].Price);
        }
    }
}
