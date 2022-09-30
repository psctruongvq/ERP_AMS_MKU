using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Transactions;
using System.Windows.Forms;

namespace PSC_ERPNew.Main
{
    public partial class frmDemoTransactionScope : Form
    {
        public frmDemoTransactionScope()
        {
            InitializeComponent();
        }


        private void PerformTransaction(string creditAccountID, string debitAccountID, double amount)
        {
            // they will be used to decide whether to commit or rollback the transaction
            bool debitResult = false;
            bool creditResult = false;

            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    using (SqlConnection con = new SqlConnection("CHUOI KET NOI"))
                    {
                        con.Open();

                        // Let us do a debit first
                        using (SqlCommand cmd = con.CreateCommand())
                        {
                            cmd.CommandType = CommandType.Text;
                            cmd.CommandText = string.Format(
                                "update Account set Amount = Amount - {0} where ID = {1}",
                                amount, debitAccountID);

                            debitResult = cmd.ExecuteNonQuery() == 1;
                        }

                        // A dummy throw just to check whether the transaction are working or not
                        throw new Exception("Let see..."); // uncomment this line to see the transaction in action

                        // And now do a credit
                        using (SqlCommand cmd = con.CreateCommand())
                        {
                            cmd.CommandType = CommandType.Text;
                            cmd.CommandText = string.Format(
                                "update Account set Amount = Amount + {0} where ID = {1}",
                                amount, creditAccountID);

                            creditResult = cmd.ExecuteNonQuery() == 1;
                        }

                        if (debitResult && creditResult)
                        {
                            // To commit the transaction 
                            ts.Complete();
                        }
                    }
                }
            }
            catch
            {
                // the transaction scope will take care of rolling back
            }
        }

    }
}
