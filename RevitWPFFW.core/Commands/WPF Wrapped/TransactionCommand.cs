using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PB.RevitWPFFW.core
{
    /// <summary>
    /// A sample wrapped transaction
    /// </summary>
    public class TransactionCommand : BaseCommand
    {
        /// <summary>
        /// Execute method for transaction
        /// </summary>
        public override void Execute()
        {

            using (Transaction tx = new Transaction(RevitDocument.CurrentDocument))
            {
                tx.Start("Transaction Name");

                //Perform transactions here

                TaskDialog.Show("Transaction Command", "Revit Transaction Succeeded");

                tx.Commit();
            }
        }
    }
}
