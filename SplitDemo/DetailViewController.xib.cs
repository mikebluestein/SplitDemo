
using System;
using System.Collections.Generic;
using System.Linq;
using MonoTouch.Foundation;
using MonoTouch.UIKit;

namespace SplitDemo
{
    public partial class DetailViewController : UIViewController
    {
        UIPopoverController _pc;
        string _detail;

        public UIPopoverController Popover {
            get { return _pc; }
            set { _pc = value; }
        }

        public string Detail {
            get { return _detail; }
            set {
                _detail = value;
                
                if (_pc != null) {
                    _pc.Dismiss (true);
                }
                
                detailLabel.Text = _detail;
            }
        }

        #region Constructors

        // The IntPtr and initWithCoder constructors are required for controllers that need 
        // to be able to be created from a xib rather than from managed code

        public DetailViewController (IntPtr handle) : base(handle)
        {
            Initialize ();
        }

        [Export("initWithCoder:")]
        public DetailViewController (NSCoder coder) : base(coder)
        {
            Initialize ();
        }

        public DetailViewController () : base("DetailViewController", null)
        {
            Initialize ();
        }

        void Initialize ()
        {
        }

        #endregion

        public override bool ShouldAutorotateToInterfaceOrientation (UIInterfaceOrientation toInterfaceOrientation)
        {
            return true;
        }

        public override void ViewDidLoad ()
        {
            base.ViewDidLoad ();
            navBar.TopItem.Title = "Detail";
        }

        public void AddNavBarButton (UIBarButtonItem button)
        {
            button.Title = "Master List";
            navBar.TopItem.SetLeftBarButtonItem (button, false);
        }

        public void RemoveNavBarButton ()
        {
            navBar.TopItem.SetLeftBarButtonItem (null, false);
        }
        
    }
}
