using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;

namespace LimitedSizeStack.UI;

/**
 * @brief Класс приложения Avalonia.
 * 
 */
public partial class App : Application {
    /**
     * @brief Инициализирует приложение Avalonia. Загружает XAML.
     * 
     */
    public override void Initialize() {
        AvaloniaXamlLoader.Load(this);
    }

    /**
     * @brief Обработчик события завершения инициализации фреймворка. 
     * 
     * Создает главное окно приложения и устанавливает его в качестве главного окна.
     */
    public override void OnFrameworkInitializationCompleted() {
        if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop) {
            var mainWindow = new MainWindow();
            desktop.MainWindow = mainWindow;
        }

        base.OnFrameworkInitializationCompleted();
    }
}
