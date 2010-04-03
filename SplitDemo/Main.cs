
using System;
using System.Collections.Generic;
using System.Linq;
using MonoTouch.Foundation;
using MonoTouch.UIKit;

namespace SplitDemo
{
    public class Application
    {
        static void Main (string[] args)
        {
            UIApplication.Main (args);
        }
    }

    public partial class AppDelegate : UIApplicationDelegate
    {

        public override bool FinishedLaunching (UIApplication app, NSDictionary options)
        {
            splitViewController.Delegate = new SplitDelegate ();
            
            UINavigationController navController = splitViewController.ViewControllers[0] as UINavigationController;
            
            if (navController != null) {
                
                MasterTableViewController master = navController.TopViewController as MasterTableViewController;
                
                if (master != null) {
                    DetailViewController detail = splitViewController.ViewControllers[1] as DetailViewController;
                    if (detail != null)
                        master.DetailVC = detail;
                }
            }
            
            window.AddSubview (splitViewController.View);
            
            window.MakeKeyAndVisible ();
            
            return true;
        }
    }
}
