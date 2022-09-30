using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Transactions;
using System.Configuration;
using System.IO;
using PSC_ERP_Digitizing.WebService.Model;
using PSC_ERP_Common;
using PSC_ERP_Digitizing.WebService;

namespace PSC_ERP_Digitizing.Server
{


    public partial class frmMain
    {
        public delegate void VoidDelegate();
        // ///////////////////////////////////
        private System.Timers.Timer _mainTimer = null;
        private Thread _serviceThread = null;
        private Boolean _timerBan = false;
        private Object _lockObj = new Object();

        // //////////////////////
        private void TimerService()
        {

            //////////////////////////////////////////////////////////////////////////
            //cai dat timer
            //
            int step = 5;

            _mainTimer = new System.Timers.Timer(TimeSpan.FromSeconds(step).Seconds * 1000);
            _mainTimer.Elapsed += (object senderz1, System.Timers.ElapsedEventArgs ez1) =>
            {
                if (!_timerBan)
                {
                    _timerBan = true;
                    lock (_lockObj)
                    {
                        #region Timer body
                        TaskUtil.InvokeCrossThread(this, () =>
                        {
                            List<Task> taskList = new List<Task>();
                            //System.Windows.Forms.MessageBox.Show("Test");
                            //duyet qua tung file trong thu muc
                            foreach (FileInfo fi in (new DirectoryInfo(_tempForIndexDirectory)).GetFiles())
                            {
                                Task task = Task.Run(() =>
                                {
                                    //chỉ ghi index nội dung file text
                                    if (fi.Extension.ToLower() == ".txt")
                                    {
                                        if (!fi.Name.Contains("Log"))
                                        {
                                            String filePath = fi.FullName;
                                            try
                                            {
                                                //lay file content
                                                String fileContentForIndex = WebService.Helper.Digitizing_GetFileContent_SmartChoice(filePath);
                                                String docId = Path.GetFileNameWithoutExtension(filePath);
                                                //bổ sung ngày 24/02/2016
                                                IndexPackage indexPackage = null;
                                                if (docId.Substring(docId.Length - 2).ToUpper() == "NS")
                                                {
                                                    indexPackage = new IndexPackage() { DocId = docId, DocFileName = fi.Name, Content = fileContentForIndex };
                                                    //ghi index
                                                    WebService.Helper.Digitizing_WriteToIndexing(indexPackage, _indexNhanSuDirectory);
                                                }
                                                else if (docId.Substring(docId.Length - 2).ToUpper() == "SH")
                                                {
                                                    indexPackage = new IndexPackage() { DocId = docId, DocFileName = fi.Name, Content = fileContentForIndex };
                                                    //ghi index
                                                    WebService.Helper.Digitizing_WriteToIndexing(indexPackage, _indexSoHoaDirectory);
                                                }
                                                //ghi index
                                                //WebService.Helper.Digitizing_WriteToIndexing(indexPackage, _indexDirectory);
                                                //di chuyen file sang converted
                                                String destFilePath_inConverted = Path.Combine(_convertedDirectory, fi.Name);
                                                WebService.Util.IOUtil.TryMoveFile(filePath, destFilePath_inConverted);
                                                WebService.Util.IOUtil.SetAllowFullAccessFileForEveryone(destFilePath_inConverted);
                                                //ghi nhận đã index
                                                Helper.Digitizing_UpdateDigitizingBag_Indexed(new Guid(docId), true);
                                            }
                                            catch (Exception ex)
                                            {
                                            }
                                        }
                                        else
                                        {
                                            try
                                            {
                                                fi.Delete();
                                            }
                                            catch (Exception ex)
                                            {
                                            }

                                        }
                                    }
                                });

                                taskList.Add(task);
                            }
                            //Task.WaitAll(taskList.ToArray());

                        });
                        /*
                        if (_serviceThread == null || _serviceThread.IsAlive == false)
                        {
                            var dele = new VoidDelegate(() =>
                                {
                                    List<Task> taskList = new List<Task>();
                                    //System.Windows.Forms.MessageBox.Show("Test");
                                    //duyet qua tung file trong thu muc
                                    foreach (FileInfo fi in (new DirectoryInfo(_tempForIndexDirectory)).GetFiles())
                                    {
                                        Task task = Task.Run(() =>
                                        {
                                            //chỉ ghi index nội dung file text
                                            if (fi.Extension.ToLower() == ".txt")
                                            {
                                                String filePath = fi.FullName;
                                                //lay file content
                                                //chi lay content cua file docx
                                                String fileContentForIndex = WebService.Helper.Digitizing_GetFileContent_SmartChoice(filePath);

                                                String docId = Path.GetFileNameWithoutExtension(filePath);

                                                IndexPackage indexPackage = new IndexPackage() { DocId = docId, DocFileName = fi.Name, Content = fileContentForIndex };
                                                //ghi index
                                                WebService.Helper.Digitizing_WriteToIndexing(indexPackage, _indexDirectory);
                                                //di chuyen file sang converted
                                                WebService.Util.IOUtil.TryMoveFile(filePath, Path.Combine(_convertedDirectory, fi.Name));
                                            }
                                        });

                                        taskList.Add(task);
                                    }
                                    //Task.WaitAll(taskList.ToArray());
                                });
                            _serviceThread = new Thread(() =>
                            {
                                if (this.InvokeRequired)
                                {
                                    this.Invoke(dele);
                                }
                                else
                                {
                                    dele.Invoke();
                                }
                            });
                            _serviceThread.Start();
                        }
                         * */
                        //xóa rác
                        foreach (FileInfo fi in (new DirectoryInfo(_trashDirectory)).GetFiles())
                        {
                            fi.Delete();
                            PSC_ERP_Digitizing.WebService.Util.IOUtil.TryDeleteFile(fi.FullName);
                        }
                        //
                        //thu gom rác bộ nhớ
                        System.GC.Collect();
                        #endregion
                    }

                    _timerBan = false;
                }

            };
            //khởi chạy timer
            this.btnStartStop.PerformClick();
        }



    }
}
