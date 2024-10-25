using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;

namespace LimitedSizeStack.UI;

/**
 * @brief ����� ���������� Avalonia.
 * 
 */
public partial class App : Application {
    /**
     * @brief �������������� ���������� Avalonia. ��������� XAML.
     * 
     */
    public override void Initialize() {
        AvaloniaXamlLoader.Load(this);
    }

    /**
     * @brief ���������� ������� ���������� ������������� ����������. 
     * 
     * ������� ������� ���� ���������� � ������������� ��� � �������� �������� ����.
     */
    public override void OnFrameworkInitializationCompleted() {
        if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop) {
            var mainWindow = new MainWindow();
            desktop.MainWindow = mainWindow;
        }

        base.OnFrameworkInitializationCompleted();
    }
}
