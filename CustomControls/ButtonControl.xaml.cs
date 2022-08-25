using System.Windows.Input;

namespace ButtonControlWithProgressbar.CustomControls;

public partial class ButtonControl : Frame
{
    public ButtonControl()
    {
        InitializeComponent();
    }
    public event EventHandler<EventArgs> Tapped;

    public static readonly BindableProperty CommandProperty = BindableProperty.Create(
        propertyName: nameof(Command),
        returnType: typeof(ICommand),
        declaringType: typeof(ButtonControl),
        defaultBindingMode: BindingMode.TwoWay);

    public ICommand Command
    {
        get => (ICommand)GetValue(CommandProperty);
        set { SetValue(CommandProperty, value); }
    }


    public static readonly BindableProperty TextProperty = BindableProperty.Create(
        propertyName: nameof(Text),
        returnType: typeof(string),
        declaringType: typeof(ButtonControl),
        defaultValue: "",
        defaultBindingMode: BindingMode.TwoWay);

    public string Text
    {
        get => (string)GetValue(TextProperty);
        set { SetValue(TextProperty, value); }
    }

    public static readonly BindableProperty LoadingTextProperty = BindableProperty.Create(
        propertyName: nameof(Text),
        returnType: typeof(string),
        declaringType: typeof(ButtonControl),
        defaultValue: "Please wait...",
        defaultBindingMode: BindingMode.OneWay);

    public string LoadingText
    {
        get => (string)GetValue(LoadingTextProperty);
        set { SetValue(LoadingTextProperty, value); }
    }

    public static readonly BindableProperty IsInProgressProperty = BindableProperty.Create(
       propertyName: nameof(IsInProgress),
       returnType: typeof(bool),
       declaringType: typeof(ButtonControl),
       defaultValue: false,
       propertyChanged: IsInProgressPropertyChanged);

    private static void IsInProgressPropertyChanged(BindableObject bindable, object oldValue, object newValue)
    {
        var controls = (ButtonControl)bindable;
        if (newValue != null)
        {
            bool isInProgress = (bool)newValue;
            if (isInProgress)
                controls.lblButtonText.Text = controls.LoadingText;
            else
                controls.lblButtonText.Text = controls.Text;
        }
    }

    public bool IsInProgress
    {
        get => (bool)GetValue(IsInProgressProperty);
        set { SetValue(IsInProgressProperty, value); }
    }

    private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
    {
        Tapped?.Invoke(sender, e);
    }
}