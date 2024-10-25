/**
 * @file LimitedSizeStack_PerformanceTest.cs
 * @brief Описание класса LimitedSizeStack_PerformanceTest, содержащего тесты производительности для класса LimitedSizeStack
 * @attention Данные тесты содержат проверки на производительность и могут занимать большое количество ресурсов при выполнении на больших объемах данных.
 */

using NUnit.Framework;

namespace LimitedSizeStack {

    /**
     * @class LimitedSizeStack_PerformanceTest
     * @brief Класс, содержащий тесты производительности для класса LimitedSizeStack
     */
    [TestFixture]
    public class LimitedSizeStack_PerformanceTest {

        /**
         * @brief Тест производительности функции Push
         * @details Push должен работать быстро, даже при большом лимите на размер стека
         * @note Время выполнения теста должно быть менее 500мс.
         * @link https://en.wikipedia.org/wiki/Stack_(abstract_data_type) Стек (википедия)
         * @see LimitedSizeStack
         * @ingroup tests
         */
        [Test, Timeout(500), Description("Push должен работать быстро, даже при большом лимите на размер стека")]
        public void Push_ShouldTakeConstantTime() {
            var undoLimit = 100000;
            var stack = new LimitedSizeStack<int>(undoLimit);
            for (var i = 0; i < 5 * undoLimit; ++i) {
                stack.Push(0);
            }
            Assert.AreEqual(undoLimit, stack.Count);
        }

        /**
         * @brief Тест производительности функции Pop
         * @details Pop должен работать быстро, даже при большом лимите на размер стека
         * @warning Внимание! Данный тест потенциально опасен для систем с недостаточным количеством памяти.
         * @bug Некоторые платформы могут иметь проблемы со стеком вызовов при выполнении данного теста.
         * @note Время выполнения теста должно быть менее 500мс.
         * @todo Добавить проверку количества освобожденной памяти при выполнении Pop
         * @ingroup tests
         */
        [Test, Timeout(500), Description("Pop должен работать быстро, даже при большом лимите на размер стека")]
        public void Pop_ShouldTakeConstantTime() {
            var undoLimit = 200000;
            var stack = new LimitedSizeStack<int>(undoLimit);
            for (var i = 0; i < undoLimit; ++i) {
                stack.Push(0);
            }
            Assert.AreEqual(undoLimit, stack.Count);
            for (var i = 0; i < undoLimit; ++i) {
                stack.Pop();
            }
            Assert.AreEqual(0, stack.Count);
        }
    }

}