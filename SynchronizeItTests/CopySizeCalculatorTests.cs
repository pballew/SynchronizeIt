using Microsoft.VisualStudio.TestTools.UnitTesting;
using SynchronizeIt;
using System.Threading;
using System.Threading.Tasks;

namespace SynchronizeItTests
{
    [TestClass]
    public class CopySizeCalculatorTests
    {
        private const string _sourceDir = @"..\..\TestData\Source";
        private const string _destDir = @"..\..\TestData\Destination";

        [TestMethod]
        public void CalculateTotalFileCopySize_TestData_ExpectedValue()
        {
            // Arrange
            CopySizeCalculator calc = new CopySizeCalculator(_sourceDir, _destDir);

            // Act
            long size = calc.CalculateTotalFileCopySize();

            // Assert
            Assert.AreEqual(104400, size);
        }

        [TestMethod]
        public void CalculateTotalFileCopySize_BigData_BigSize()
        {
            // Arrange
            CopySizeCalculator calc = new CopySizeCalculator(@"C:\", _destDir);

            // Act
            long size = calc.CalculateTotalFileCopySize();

            // Assert
            Assert.IsTrue(size > 100000000);
        }

        [TestMethod]
        public void CalculateTotalFileCopySize_WorkerThread_ExpectedValue()
        {
            // Arrange
            CopySizeCalculator calc = new CopySizeCalculator(_sourceDir, _destDir);
            long size = 0;

            // Act
            Thread _fileSizeEstimatorThread = new Thread(new ThreadStart( () =>
            {
                size = calc.CalculateTotalFileCopySize();
            }));
            _fileSizeEstimatorThread.Start();
            _fileSizeEstimatorThread.Join();

            // Assert
            Assert.AreEqual(104400, size);
        }
    }
}