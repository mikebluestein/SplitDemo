using System;
using System.Collections.Generic;
using System.Linq;
using MonoTouch.Foundation;
using MonoTouch.UIKit;

namespace SplitDemo
{
    [MonoTouch.Foundation.Register("MasterTableViewController")]
    public partial class MasterTableViewController : UITableViewController
    {
        static NSString kCellIdentifier = new NSString ("MyIdentifier");

        public DetailViewController DetailVC { get; set; }

        public MasterTableViewController (IntPtr p) : base(p)
        {
        }

        class DataSource : UITableViewDataSource
        {
            MasterTableViewController tvc;

            public DataSource (MasterTableViewController tvc)
            {
                this.tvc = tvc;
            }

            public override int RowsInSection (UITableView tableView, int section)
            {
                return 100;
            }

            public override UITableViewCell GetCell (UITableView tableView, NSIndexPath indexPath)
            {
                var cell = tableView.DequeueReusableCell (kCellIdentifier);
                if (cell == null) {
                    cell = new UITableViewCell (UITableViewCellStyle.Default, kCellIdentifier);
                }
                
                cell.TextLabel.Text = "item " + indexPath.Row.ToString ();
                
                return cell;
            }
        }

        class TableDelegate : UITableViewDelegate
        {
            MasterTableViewController tvc;

            public TableDelegate (MasterTableViewController tvc)
            {
                this.tvc = tvc;
            }

            public override void RowSelected (UITableView tableView, NSIndexPath indexPath)
            {
                Console.WriteLine ("SplitDemo: Row selected {0}", indexPath.Row);
                
                this.tvc.DetailVC.Detail = "item " + indexPath.Row.ToString ();
            }
        }

        public override void ViewDidLoad ()
        {
            base.ViewDidLoad ();
            Title = "Master";
            
            TableView.Delegate = new TableDelegate (this);
            TableView.DataSource = new DataSource (this);
        }

        public override bool ShouldAutorotateToInterfaceOrientation (UIInterfaceOrientation toInterfaceOrientation)
        {
            return true;
        }
        
        
    }
}

