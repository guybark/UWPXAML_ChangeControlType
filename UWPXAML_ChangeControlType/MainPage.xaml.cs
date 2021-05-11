using Windows.UI.Xaml.Automation.Peers;
using Windows.UI.Xaml.Controls;

namespace UWPXAML_ChangeControlType
{
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }
    }

    // A custom HyperlinkButton which gets exposed through UIA as being a Button.
    public class MyButtonLikeHyperlinkButton : HyperlinkButton
    {
        protected override AutomationPeer OnCreateAutomationPeer()
        {
            return new MyButtonLikeHyperlinkButtonAutomationPeer(this);
        }
    }

    public class MyButtonLikeHyperlinkButtonAutomationPeer : HyperlinkButtonAutomationPeer
    {
        public MyButtonLikeHyperlinkButtonAutomationPeer(MyButtonLikeHyperlinkButton owner) :
            base(owner)
        {
        }

        protected override AutomationControlType GetAutomationControlTypeCore()
        {
            // Despite this being a HyperlinkButton, let's say that for some reason it's 
            // more helpful to customers for it to be exposed through UIA as a Button.
            // Note: By default don't do this. Rather use a Button control if semantically
            // this thing is a button.
            return AutomationControlType.Button;
        }
    }
}
