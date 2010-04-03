
using System;
using MonoTouch.UIKit;

namespace SplitDemo
{


    public class SplitDelegate : UISplitViewControllerDelegate
    {

        public override void WillHideViewController (UISplitViewController svc, UIViewController aViewController, UIBarButtonItem barButtonItem, UIPopoverController pc)
        {
            DetailViewController dvc = svc.ViewControllers[1] as DetailViewController;
            
            if (dvc != null) {
                dvc.AddNavBarButton (barButtonItem);
                dvc.Popover = pc;
            }
        }

        public override void WillShowViewController (UISplitViewController svc, UIViewController aViewController, UIBarButtonItem button)
        {
            DetailViewController dvc = svc.ViewControllers[1] as DetailViewController;
            
            if (dvc != null) {
                dvc.RemoveNavBarButton ();
                dvc.Popover = null;
            }
        }
        
    }
}
