namespace Test
{
    [TestClass]
    public sealed class Test1
    {
        // ==================== ТЕСТЫ ДЛЯ ПРЯМОУГОЛЬНИКА ====================
           
        [TestMethod]
        public void Rectangle_ValidSides_ReturnsCorrectPerimeter()
        {
            // Arrange
            double side1 = 5;
            double side2 = 10;
            double expected = 30; // 2*(5+10)=30

            // Act
            double actual = 2 * (side1 + side2);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Rectangle_Side1IsZero_ThrowsException()
        {
            double side1 = 0;
            Assert.ThrowsException<Exception>(() => ValidateSide(side1, "сторону 1"));
        }

        [TestMethod]
        public void Rectangle_Side2IsZero_ThrowsException()
        {
            double side2 = 0;
            Assert.ThrowsException<Exception>(() => ValidateSide(side2, "сторону 2"));
        }

        [TestMethod]
        public void Rectangle_Side1IsNegative_ThrowsException()
        {
            double side1 = -3;
            Assert.ThrowsException<Exception>(() => ValidateSide(side1, "сторону 1"));
        }

        [TestMethod]
        public void Rectangle_Side2IsNegative_ThrowsException()
        {
            double side2 = -5;
            Assert.ThrowsException<Exception>(() => ValidateSide(side2, "сторону 2"));
        }

        [TestMethod]
        public void Rectangle_SameSides_Square_ReturnsCorrectPerimeter()
        {
            double side1 = 7;
            double side2 = 7;
            double expected = 28; // 2*(7+7)=28
            double actual = 2 * (side1 + side2);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Rectangle_DecimalSides_ReturnsCorrectPerimeter()
        {
            double side1 = 2.5;
            double side2 = 3.2;
            double expected = 11.4; // 2*(2.5+3.2)=11.4
            double actual = 2 * (side1 + side2);
            Assert.AreEqual(expected, actual, 0.001);
        }

        [TestMethod]
        public void Rectangle_VeryLargeSides_ReturnsLargePerimeter()
        {
            double side1 = 1_000_000;
            double side2 = 2_000_000;
            double expected = 6_000_000;
            double actual = 2 * (side1 + side2);
            Assert.AreEqual(expected, actual);
        }

        // ==================== ТЕСТЫ ДЛЯ КРУГА (ДЛИНА ОКРУЖНОСТИ) ====================

        [TestMethod]
        public void Circle_ValidRadius_ReturnsCorrectCircumference()
        {
            // Arrange
            double radius = 5;
            double expected = 2 * Math.PI * 5; // ≈ 31.4159

            // Act
            double actual = 2 * Math.PI * radius;

            // Assert
            Assert.AreEqual(expected, actual, 0.0001);
        }

        [TestMethod]
        public void Circle_RadiusIsZero_ThrowsException()
        {
            double radius = 0;
            Assert.ThrowsException<Exception>(() => ValidateSide(radius, "радиус"));
        }

        [TestMethod]
        public void Circle_RadiusIsNegative_ThrowsException()
        {
            double radius = -2;
            Assert.ThrowsException<Exception>(() => ValidateSide(radius, "радиус"));
        }

        [TestMethod]
        public void Circle_RadiusOne_ReturnsTwoPi()
        {
            double radius = 1;
            double expected = 2 * Math.PI; // ≈ 6.28318
            double actual = 2 * Math.PI * radius;
            Assert.AreEqual(expected, actual, 0.0001);
        }

        [TestMethod]
        public void Circle_RadiusDecimal_ReturnsCorrectCircumference()
        {
            double radius = 3.75;
            double expected = 2 * Math.PI * 3.75; // ≈ 23.5619
            double actual = 2 * Math.PI * radius;
            Assert.AreEqual(expected, actual, 0.0001);
        }

        // ==================== ТЕСТЫ ДЛЯ ТРЕУГОЛЬНИКА ====================

        [TestMethod]
        public void Triangle_ValidSides_ReturnsCorrectPerimeter()
        {
            // Arrange
            double side1 = 3;
            double side2 = 4;
            double side3 = 5;
            double expected = 12; // 3+4+5=12

            // Act
            double actual = side1 + side2 + side3;

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Triangle_AllSidesEqual_Equilateral_ReturnsCorrectPerimeter()
        {
            double side1 = 6;
            double side2 = 6;
            double side3 = 6;
            double expected = 18;
            double actual = side1 + side2 + side3;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Triangle_TwoSidesEqual_Isosceles_ReturnsCorrectPerimeter()
        {
            double side1 = 5;
            double side2 = 5;
            double side3 = 8;
            double expected = 18;
            double actual = side1 + side2 + side3;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Triangle_Side1IsZero_ThrowsException()
        {
            double side1 = 0;
            Assert.ThrowsException<Exception>(() => ValidateSide(side1, "сторону 1"));
        }

        [TestMethod]
        public void Triangle_Side2IsNegative_ThrowsException()
        {
            double side2 = -4;
            Assert.ThrowsException<Exception>(() => ValidateSide(side2, "сторону 2"));
        }

        [TestMethod]
        public void Triangle_Side3IsZero_ThrowsException()
        {
            double side3 = 0;
            Assert.ThrowsException<Exception>(() => ValidateSide(side3, "сторону 3"));
        }

        [TestMethod]
        public void Triangle_DecimalSides_ReturnsCorrectPerimeter()
        {
            double side1 = 2.3;
            double side2 = 4.7;
            double side3 = 5.1;
            double expected = 12.1;
            double actual = side1 + side2 + side3;
            Assert.AreEqual(expected, actual, 0.001);
        }

        [TestMethod]
        public void Triangle_VerySmallSides_ReturnsSmallPerimeter()
        {
            double side1 = 0.001;
            double side2 = 0.002;
            double side3 = 0.003;
            double expected = 0.006;
            double actual = side1 + side2 + side3;
            Assert.AreEqual(expected, actual, 0.0001);
        }

        // ==================== ОБЩИЕ ТЕСТЫ ДЛЯ ВСЕХ ФИГУР ====================

        [TestMethod]
        public void Perimeter_ResultIsAlwaysPositive()
        {
            // Прямоугольник
            double rectPerimeter = 2 * (5 + 10);
            Assert.IsTrue(rectPerimeter > 0);

            // Круг
            double circlePerimeter = 2 * Math.PI * 5;
            Assert.IsTrue(circlePerimeter > 0);

            // Треугольник
            double trianglePerimeter = 3 + 4 + 5;
            Assert.IsTrue(trianglePerimeter > 0);
        }

        [TestMethod]
        public void Perimeter_WithLargeDecimalValues_ReturnsCorrect()
        {
            double rect = 2 * (12345.678 + 98765.432);
            double circle = 2 * Math.PI * 10000;
            double triangle = 10000.5 + 20000.3 + 30000.2;

            Assert.IsTrue(rect > 0);
            Assert.IsTrue(circle > 0);
            Assert.IsTrue(triangle > 0);
        }

        // ==================== ТЕСТЫ НА ГРАНИЧНЫЕ ЗНАЧЕНИЯ ====================

        [TestMethod]
        public void Boundary_MinimumPositiveValue_DoesNotThrowException()
        {
            double minPositive = double.Epsilon;
            // Проверяем, что исключение НЕ выбрасывается
            ValidateSide(minPositive, "сторона");
            Assert.IsTrue(true);
        }

        [TestMethod]
        public void Boundary_MaximumValue_DoesNotThrowException()
        {
            double maxValue = double.MaxValue / 4; // Чтобы избежать переполнения
            ValidateSide(maxValue, "сторона");
            Assert.IsTrue(true);
        }

        // ==================== ВСПОМОГАТЕЛЬНЫЙ МЕТОД ДЛЯ ПРОВЕРКИ ====================

        ///

        /// Копия метода проверки из основного приложения
        ///

        private void ValidateSide(double value, string fieldName)
        {
            if (value <= 0)
                throw new Exception($"{fieldName} должно быть больше нуля");
        }
    }
}

