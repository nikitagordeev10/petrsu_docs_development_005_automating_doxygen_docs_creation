/**
 * @file Program.cs
 * @brief Основной файл приложения. 
 */

using System;
using Avalonia;
using Avalonia.ReactiveUI;

namespace LimitedSizeStack.UI;

internal static class Program {
    /**
     * @brief Основной метод, который запускает приложение.
     * @param args Аргументы командной строки.
     */
    [STAThread]
    public static void Main(string[] args) => BuildAvaloniaApp()
    .StartWithClassicDesktopLifetime(args);

    /**
     * @brief Конфигурация приложения Avalonia.
     * @return Возвращает новый экземпляр класса AppBuilder с настроенной конфигурацией Avalonia.
     */
    public static AppBuilder BuildAvaloniaApp()
    => AppBuilder.Configure<App>()
      .UsePlatformDetect()
      .LogToTrace()
      .UseReactiveUI();
}