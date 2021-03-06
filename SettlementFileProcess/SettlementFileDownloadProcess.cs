using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using System.Collections;
using System.Configuration;
using System.Resources;
using System.Threading;
using System.IO;
using System.Net;
using AppConfig;
using ACE.Banking.MPU.Businesslogic;
using ACE.Banking.MPU.CollectionSuit;
using FTP.Library;
using System.Globalization;

namespace SettlementFileProcess
{
    public partial class SettlementFileDownloadProcess : Form
    {
        public SettlementFileDownloadProcess()
        {
            InitializeComponent();
        }

        #region Fields...

        private string downloadtime = string.Empty;
        private string type = string.Empty;
        private string FileName = string.Empty;
        private string MerchantStFile = string.Empty;
        private string MemberBankSTF = string.Empty;
        private string TrailFilePath = string.Empty;
        private string MemberTrailFilePath = String.Empty;
        private string MerchantTrailFilePath = String.Empty;
        private string AcquireFilePath = string.Empty;
        private string IssuerFilePath = string.Empty;
        private string AcquireErrFilePath = string.Empty;
        private string IssuerErrFilePath = string.Empty;
        private string MasterT464FilePath = string.Empty;
        private Thread DownloadThd;

        #endregion Fields...

        #region Customize Events...

        /// <summary>
        /// Tracing Log file...
        /// </summary>
        /// <param name="txt"></param>
        /// <param name="log"></param>
        private delegate void _TraceLog(TextBox txt, string log);

        private void TraceLog(TextBox txt, string log)
        {
            if (txt.InvokeRequired)
            {
                txt.Invoke(new _TraceLog(TraceLog), txt, log);
            }
            else
                txt.Text = txt.Text + Environment.NewLine + log;
        }

        /// <summary>
        /// Download start...
        /// </summary>
        private void StartDownload()
        {
            SequenceLog Seqlog = new SequenceLog();
            try
            {
                string SettlementFilePath = string.Empty;
                FileName = Convert.ToString(DateTime.Now.Day.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString());
                Seqlog.TraceLog("Download Process Start at = >" + DateTime.Now, FileName);
                //

                SettlementFilePath = Application.StartupPath + @"\";
                SettlementFilePath = System.IO.Path.Combine(SettlementFilePath, "MPUSettlementFile");
                System.IO.Directory.CreateDirectory(SettlementFilePath);
                string _DT = DateTime.Now.Day + "-" + DateTime.Now.Month + "-" + DateTime.Now.Year;

                SettlementFilePath = System.IO.Path.Combine(SettlementFilePath, _DT);
                System.IO.Directory.CreateDirectory(SettlementFilePath);

                MerchantStFile = System.IO.Path.Combine(SettlementFilePath, "MerchantSTF");
                System.IO.Directory.CreateDirectory(MerchantStFile);
                MerchantStFile = System.IO.Path.Combine(MerchantStFile, _DT);
                System.IO.Directory.CreateDirectory(MerchantStFile);

                MemberBankSTF = System.IO.Path.Combine(SettlementFilePath, "MemberBankSTF");
                System.IO.Directory.CreateDirectory(MemberBankSTF);
                MemberBankSTF = System.IO.Path.Combine(MemberBankSTF, _DT);
                System.IO.Directory.CreateDirectory(MemberBankSTF);

                TrailFilePath = System.IO.Path.Combine(SettlementFilePath, "TrailFile");
                System.IO.Directory.CreateDirectory(TrailFilePath);

                MemberTrailFilePath = System.IO.Path.Combine(TrailFilePath, "MemberTrailFile");
                System.IO.Directory.CreateDirectory(MemberTrailFilePath);
                MemberTrailFilePath = System.IO.Path.Combine(MemberTrailFilePath, _DT);
                System.IO.Directory.CreateDirectory(MemberTrailFilePath);

                MerchantTrailFilePath = System.IO.Path.Combine(TrailFilePath, "MerchantTrailFile");
                System.IO.Directory.CreateDirectory(MerchantTrailFilePath);
                MerchantTrailFilePath = System.IO.Path.Combine(MerchantTrailFilePath, _DT);
                System.IO.Directory.CreateDirectory(MerchantTrailFilePath);

                MasterT464FilePath = System.IO.Path.Combine(TrailFilePath, "Mastert464File");
                System.IO.Directory.CreateDirectory(MasterT464FilePath);
                MasterT464FilePath = System.IO.Path.Combine(MasterT464FilePath, _DT);
                System.IO.Directory.CreateDirectory(MasterT464FilePath);

                string downloadpath = Convert.ToString(ConfigurationManager.AppSettings["downloadpath"]);
                string channel = Convert.ToString(ConfigurationManager.AppSettings["channel"]);

                string hostname = Convert.ToString(ConfigurationManager.AppSettings["downloadpathftp"]);
                string username = Convert.ToString(ConfigurationManager.AppSettings["username"]);
                string password = Convert.ToString(ConfigurationManager.AppSettings["password"]);

              
                string downloadstd = DateTime.Now.AddDays(-1).ToString("ddMMyyyy");

              
                hostname += "//" + Convert.ToString(downloadstd);
                string ecommercepath = downloadpath + "ECOM" + "\\";

                if (channel.ToLower() == "ftp")
                {
                    /*** CLEAN FILES IF THEY EXIST ***/
                    CleantheFileOnLocal(downloadpath);

                    /*** E-COMMERCE FILES DOWNLOAD ***/
                    string HostNameForECom = hostname + "//" + DateTime.Now.ToString("ddMMyyyy");
                    if (CheckDirExistOnFtp(HostNameForECom, username, password))
                    {
                        if (!Directory.Exists(ecommercepath))
                            Directory.CreateDirectory(ecommercepath);

                        DownloadFromFTPServer(HostNameForECom, username, password, ecommercepath);
                    }

                    /*** POS SETTLEMENT FILES DOWNLOAD ***/
                    DownloadFromFTPServer(hostname, username, password, downloadpath);
                }

                /*** GET FILES FROM MPU PATH & E-COMMERCE PATH ***/
                if (Directory.Exists(ecommercepath))
                {
                    if (!FileDownloadFromDirectory(downloadpath) || !FileDownloadFromDirectory(ecommercepath))
                    {
                        MessageBox.Show("Download Process Fail at => " + DateTime.Now);
                        throw new Exception("Download Process Fail at => " + DateTime.Now);
                    }
                }
                else
                {
                    if (!FileDownloadFromDirectory(downloadpath))
                    {
                        MessageBox.Show("Download Process Fail at => " + DateTime.Now);
                        throw new Exception("Download Process Fail at => " + DateTime.Now);
                    }
                }
                MessageBox.Show("Download process finish at => " + DateTime.Now);
                Seqlog.TraceLog("Download Process finish at = >" + DateTime.Now, FileName);
            }
            catch (Exception ex)
            {
                Seqlog.TraceLog("Download Process Fail at = >" + DateTime.Now, FileName);
                Seqlog.TraceLog("Err Desc = > " + ex.Message, FileName);
            }
        }

        /// <summary>
        /// Check whether the necessory directory is exist on FTP server or not!
        /// </summary>
        /// <param name="path">URI for necessory directory</param>
        /// <param name="user">credential username for FTP server</param>
        /// <param name="password">credential password for FTP server</param>
        /// <returns></returns>
        private bool CheckDirExistOnFtp(string path, string user, string password)
        {
            bool dirExist = false;

            FtpWebRequest req = (FtpWebRequest)WebRequest.Create(path);
            req.Method = WebRequestMethods.Ftp.ListDirectory;
            req.Credentials = new NetworkCredential(user, password);

            try
            {
                using (req.GetResponse())
                { dirExist = true; }
            }
            catch (WebException)
            {
                MessageBox.Show("Directory not found");
            }

            return dirExist;
        }

        /// <summary>
        /// Clean the Folder containing all files if exists!
        /// </summary>
        /// <param name="downloadpath"></param>
        private void CleantheFileOnLocal(string downloadpath)
        {
            try
            {
                System.IO.DirectoryInfo downloadedMessageInfo = new DirectoryInfo(downloadpath);

                foreach (FileInfo file in downloadedMessageInfo.GetFiles())
                {
                    file.Delete();
                }
                foreach (DirectoryInfo dir in downloadedMessageInfo.GetDirectories())
                {
                    dir.Delete(true);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /*** FILE READ ARE INSERTED INTO DATABASE... ***/

        private bool CoreBankingSettlementFileDownload(DateTime STFDate)
        {
            SequenceLog Seqlog = new SequenceLog();
            try
            {
                Seqlog.TraceLog("============================================", FileName);
                Seqlog.TraceLog("Core-Banking Settlement File Download Start At = > " + DateTime.Now, FileName);

             
                DMLStringExecuterController DMLCtrl = new DMLStringExecuterController();
                var test = STFDate.ToString("yyyy/MM/dd");
                DataTable MPUSTFDate = DMLCtrl.DMLStringExecuter("select CutOffStartDate,CutOffEndDate from CutOffDetail_Info where TransType='DEN' and GroupChannel='MPU' and convert(varchar, TransactionDate, 111)=convert(varchar, '" + test+ "', 111)");
                if (MPUSTFDate.Rows.Count < 0) throw new Exception("There is no mpu settlement date.");

                if (MPUSTFDate.Rows.Count > 0)
                {
                    Seqlog.TraceLog("Have Cutoff date in Cutoff Detail info:= > " + DateTime.Now, FileName);
                    Seqlog.TraceLog("============================================", FileName);
                }
                else
                {
                    Seqlog.TraceLog("No Cutoff date in Cutoff Detail info:= > " + DateTime.Now, test);
                    Seqlog.TraceLog("============================================", FileName);
                }

                CBSMPUSFT_Controller CBSMPUCtrl = new CBSMPUSFT_Controller();
                string _rcode = "00";
                if (_rcode != "00")
                    throw new Exception("CBS Settlement File Generation Fail.Response Code is = > " + _rcode);
                else
                    MessageBox.Show("CutOff Complete!");

                Seqlog.TraceLog("Core-Banking Settlement File Download Finish At = > " + DateTime.Now, FileName);
                Seqlog.TraceLog("============================================", FileName);

                return true;
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message);
                Seqlog.TraceLog("Core-Banking Settlement File Download Fail At = > " + DateTime.Now, FileName);
                Seqlog.TraceLog("Err Description = > " + ex.Message, FileName);
                Seqlog.TraceLog("============================================", FileName);
                return false;
            }
        }

        /*** READ FILES FROM "TEMP" DIRECTORY AND COPY TO APP_PATH\MPUSETTLEMENTFILE\- ***/

        private bool FileDownloadFromDirectory(string DownloadPath)
        {
            SequenceLog seqlog = new SequenceLog();

            if (getLastPath(DownloadPath).Equals("ECOM"))
            {
                string subFolder = "ECOM";
                Directory.CreateDirectory(MerchantStFile + Path.DirectorySeparatorChar + subFolder);
                Directory.CreateDirectory(MerchantTrailFilePath + Path.DirectorySeparatorChar + subFolder);

                /*** COPY FILES TO MPU/-/ECOM/ FOLDER ***/

                #region Copy MPU/Ecom

                try
                {
                    seqlog.TraceLog("====================================", FileName);
                    seqlog.TraceLog("File download Processs start at = >" + DateTime.Now, FileName);
                    string[] FileNameSuit = Directory.GetFiles(DownloadPath);
                    string filetype = string.Empty;
                    if (FileNameSuit.Length <= 0)
                        throw new Exception("There is no file at path = > " + DownloadPath);

                    for (int i = 0; i < FileNameSuit.Length; i++)
                    {
                        if (MPUFileChecking(FileNameSuit[i].Replace(DownloadPath, ""), out filetype))
                        {
                            switch (filetype)
                            {
                               
                                case "MBAS": //Member Bank Ecom+POS Acq Settlement File Process
                                    seqlog.TraceLog("Merchant Settlement File = > " + MemberBankSTF + "\\" + subFolder + FileNameSuit[i].Replace(DownloadPath, "\\") + " download start at = > " + DateTime.Now, FileName);
                                    File.Copy(FileNameSuit[i], MemberBankSTF + "\\" + FileNameSuit[i].Replace(DownloadPath, "\\"), true);
                                    seqlog.TraceLog("Merchant Settlement File = > " + MerchantStFile + "\\" + subFolder + FileNameSuit[i].Replace(DownloadPath, "\\") + " download finish at = > " + DateTime.Now, FileName);
                                    break;

                                case "MBAE": //Member bank Settlement Detail Transaction Process
                                    seqlog.TraceLog("Memberbank Trail File = > " + MemberTrailFilePath + FileNameSuit[i].Replace(DownloadPath, "\\") + " download start at  = > " + DateTime.Now, FileName);
                                    File.Copy(FileNameSuit[i], MemberTrailFilePath + FileNameSuit[i].Replace(DownloadPath, "\\"), true);
                                    seqlog.TraceLog("Memberbank Trail File = > " + MemberTrailFilePath + FileNameSuit[i].Replace(DownloadPath, "\\") + " download finish at  = > " + DateTime.Now, FileName);
                                    break;

                                case "MBAC": //Member bank Settlement Detail Transaction Process
                                    seqlog.TraceLog("Memberbank Trail File = > " + MemberTrailFilePath + FileNameSuit[i].Replace(DownloadPath, "\\") + " download start at  = > " + DateTime.Now, FileName);
                                    File.Copy(FileNameSuit[i], MemberTrailFilePath + FileNameSuit[i].Replace(DownloadPath, "\\"), true);
                                    seqlog.TraceLog("Memberbank Trail File = > " + MemberTrailFilePath + FileNameSuit[i].Replace(DownloadPath, "\\") + " download finish at  = > " + DateTime.Now, FileName);
                                    break;

                                case "MBIS": //Member bank   Ecom+POS Iss Settlement File Process
                                    seqlog.TraceLog("Merchant Settlement File = > " + MemberBankSTF + "\\" + subFolder + FileNameSuit[i].Replace(DownloadPath, "\\") + " download start at = > " + DateTime.Now, FileName);
                                    File.Copy(FileNameSuit[i], MemberBankSTF + "\\" + FileNameSuit[i].Replace(DownloadPath, "\\"), true);
                                    seqlog.TraceLog("Merchant Settlement File = > " + MerchantStFile + "\\" + subFolder + FileNameSuit[i].Replace(DownloadPath, "\\") + " download finish at = > " + DateTime.Now, FileName);
                                    break;

                                case "MBIE": //Member bank Settlement  Ecom+Pos Acq Detail Transaction Process
                                    seqlog.TraceLog("Memberbank Trail File = > " + MemberTrailFilePath + FileNameSuit[i].Replace(DownloadPath, "\\") + " download start at  = > " + DateTime.Now, FileName);
                                    File.Copy(FileNameSuit[i], MemberTrailFilePath + FileNameSuit[i].Replace(DownloadPath, "\\"), true);
                                    seqlog.TraceLog("Memberbank Trail File = > " + MemberTrailFilePath + FileNameSuit[i].Replace(DownloadPath, "\\") + " download finish at  = > " + DateTime.Now, FileName);
                                    break;

                                case "MBIC": //Member bank Ecom+Pos Issusing Detail Transaction Process
                                    seqlog.TraceLog("Memberbank Trail File = > " + MemberTrailFilePath + FileNameSuit[i].Replace(DownloadPath, "\\") + " download start at  = > " + DateTime.Now, FileName);
                                    File.Copy(FileNameSuit[i], MemberTrailFilePath + FileNameSuit[i].Replace(DownloadPath, "\\"), true);
                                    seqlog.TraceLog("Memberbank Trail File = > " + MemberTrailFilePath + FileNameSuit[i].Replace(DownloadPath, "\\") + " download finish at  = > " + DateTime.Now, FileName);
                                    break;

                                case "MCS": //Merchant Settlement File Process
                                    seqlog.TraceLog("Merchant Settlement File = > " + MerchantStFile + "\\" + subFolder + FileNameSuit[i].Replace(DownloadPath, "\\") + " download start at = > " + DateTime.Now, FileName);
                                    File.Copy(FileNameSuit[i], MerchantStFile + "\\" + subFolder + FileNameSuit[i].Replace(DownloadPath, "\\"), true);
                                    seqlog.TraceLog("Merchant Settlement File = > " + MerchantStFile + "\\" + subFolder + FileNameSuit[i].Replace(DownloadPath, "\\") + " download finish at = > " + DateTime.Now, FileName);
                                    break;

                                case "MCD": //Merchant Settlement Detail Transaction Process
                                    seqlog.TraceLog("Merchant Trail File = > " + MerchantTrailFilePath + "\\" + subFolder + FileNameSuit[i].Replace(DownloadPath, "\\") + " download start at = > " + DateTime.Now, FileName);
                                    File.Copy(FileNameSuit[i], MerchantTrailFilePath + "\\" + subFolder + FileNameSuit[i].Replace(DownloadPath, "\\"), true);
                                    seqlog.TraceLog("Merchant Trail File = > " + MerchantTrailFilePath + "\\" + subFolder + FileNameSuit[i].Replace(DownloadPath, "\\") + " download finish at = > " + DateTime.Now, FileName);
                                    break;

                                case "T464":
                                    seqlog.TraceLog("Master Trail File = > " + MasterT464FilePath + "\\" + subFolder + FileNameSuit[i].Replace(DownloadPath, "\\") + " download start at  = > " + DateTime.Now, FileName);
                                    File.Copy(FileNameSuit[i], MasterT464FilePath + "\\" + subFolder + FileNameSuit[i].Replace(DownloadPath, "\\"), true);
                                    seqlog.TraceLog("Master Trail File = > " + MasterT464FilePath + "\\" + subFolder + FileNameSuit[i].Replace(DownloadPath, "\\") + " download finish at  = > " + DateTime.Now, FileName);
                                    break;

                                default:
                                    break;
                            }
                        }
                    }
                    seqlog.TraceLog("File download Processs finish at = >" + DateTime.Now, FileName);
                    seqlog.TraceLog("====================================", FileName);
                    return true;
                }
                catch (Exception ex)
                {
                    seqlog.TraceLog("File download Processs fail at = >" + DateTime.Now, FileName);
                    seqlog.TraceLog("Err Desc = > " + ex.Message, FileName);
                    seqlog.TraceLog("====================================", FileName);
                    return false;
                }

                #endregion Copy MPU/Ecom
            }
            else
            {
                /*** COPY FILES TO MPU/-/ FOLDER ***/

                #region Copy MPU...

                try
                {
                    seqlog.TraceLog("====================================", FileName);
                    seqlog.TraceLog("File download Processs start at = >" + DateTime.Now, FileName);
                    string[] FileNameSuit = Directory.GetFiles(DownloadPath);
                    string filetype = string.Empty;
                    if (FileNameSuit.Length <= 0)
                        throw new Exception("There is no file at path = > " + DownloadPath);

                    for (int i = 0; i < FileNameSuit.Length; i++)
                    {
                        if (MPUFileChecking(FileNameSuit[i].Replace(DownloadPath, ""), out filetype))
                        {
                            switch (filetype)
                            {
                                case "MBScom": //Member Bank Settlement File Process
                                    seqlog.TraceLog("Member Bank File = > " + MemberBankSTF + FileNameSuit[i].Replace(DownloadPath, "\\") + " download start at = > " + DateTime.Now, FileName);
                                    File.Copy(FileNameSuit[i], MemberBankSTF + FileNameSuit[i].Replace(DownloadPath, "\\"), true);
                                    seqlog.TraceLog("Member Bank File = > " + MemberBankSTF + FileNameSuit[i].Replace(DownloadPath, "\\") + " download finish at = > " + DateTime.Now, FileName);
                                    break;

                                case "MCD": //Merchant Settlement Detail Transaction Process
                                    seqlog.TraceLog("Merchant Trail File = > " + MerchantTrailFilePath + FileNameSuit[i].Replace(DownloadPath, "\\") + " download start at = > " + DateTime.Now, FileName);
                                    File.Copy(FileNameSuit[i], MerchantTrailFilePath + FileNameSuit[i].Replace(DownloadPath, "\\"), true);
                                    seqlog.TraceLog("Merchant Trail File = > " + MerchantTrailFilePath + FileNameSuit[i].Replace(DownloadPath, "\\") + " download finish at = > " + DateTime.Now, FileName);
                                    break;

                                case "MBICom": //Member Bank Issuing Transaction Process
                                    seqlog.TraceLog("Memberbank Trail File = > " + MemberTrailFilePath + FileNameSuit[i].Replace(DownloadPath, "\\") + " download start at  = > " + DateTime.Now, FileName);
                                    File.Copy(FileNameSuit[i], MemberTrailFilePath + FileNameSuit[i].Replace(DownloadPath, "\\"), true);
                                    seqlog.TraceLog("Memberbank Trail File = > " + MemberTrailFilePath + FileNameSuit[i].Replace(DownloadPath, "\\") + " download finish at  = > " + DateTime.Now, FileName);
                                    break;

                                case "MBACom": //Member Bank Acquiring Transaction Process
                                    seqlog.TraceLog("Memberbank Trail File = > " + MemberTrailFilePath + FileNameSuit[i].Replace(DownloadPath, "\\") + " download start at  = > " + DateTime.Now, FileName);
                                    File.Copy(FileNameSuit[i], MemberTrailFilePath + FileNameSuit[i].Replace(DownloadPath, "\\"), true);
                                    seqlog.TraceLog("Memberbank Trail File = > " + MemberTrailFilePath + FileNameSuit[i].Replace(DownloadPath, "\\") + " download finish at  = > " + DateTime.Now, FileName);
                                    break;

                                case "MBAcomE": //Member Bank Acquiring Transaction Err Process
                                    seqlog.TraceLog("Memberbank Trail File = > " + MemberTrailFilePath + FileNameSuit[i].Replace(DownloadPath, "\\") + " download start at  = > " + DateTime.Now, FileName);
                                    File.Copy(FileNameSuit[i], MemberTrailFilePath + FileNameSuit[i].Replace(DownloadPath, "\\"), true);
                                    seqlog.TraceLog("Memberbank Trail File = > " + MemberTrailFilePath + FileNameSuit[i].Replace(DownloadPath, "\\") + " download finish at  = > " + DateTime.Now, FileName);
                                    break;
                                case "BCOM":
                                    seqlog.TraceLog("BCOM File = > " + MemberTrailFilePath + FileNameSuit[i].Replace(DownloadPath, "\\") + " download start at  = > " + DateTime.Now, FileName);
                                    File.Copy(FileNameSuit[i], MemberTrailFilePath + FileNameSuit[i].Replace(DownloadPath, "\\"), true);
                                    seqlog.TraceLog("BCOM File = > " + MemberTrailFilePath + FileNameSuit[i].Replace(DownloadPath, "\\") + " download finish at  = > " + DateTime.Now, FileName);
                                    break;

                                case "MBIcomE": //Member Bank Issuing Transaction Err Process
                                    seqlog.TraceLog("Memberbank Trail File = > " + MemberTrailFilePath + FileNameSuit[i].Replace(DownloadPath, "\\") + " download start at  = > " + DateTime.Now, FileName);
                                    File.Copy(FileNameSuit[i], MemberTrailFilePath + FileNameSuit[i].Replace(DownloadPath, "\\"), true);
                                    seqlog.TraceLog("Memberbank Trail File = > " + MemberTrailFilePath + FileNameSuit[i].Replace(DownloadPath, "\\") + " download finish at  = > " + DateTime.Now, FileName);
                                    break;

                                case "T464":
                                    seqlog.TraceLog("Master Trail File = > " + MasterT464FilePath + FileNameSuit[i].Replace(DownloadPath, "\\") + " download start at  = > " + DateTime.Now, FileName);
                                    File.Copy(FileNameSuit[i], MasterT464FilePath + FileNameSuit[i].Replace(DownloadPath, "\\"), true);
                                    seqlog.TraceLog("Master Trail File = > " + MasterT464FilePath + FileNameSuit[i].Replace(DownloadPath, "\\") + " download finish at  = > " + DateTime.Now, FileName);
                                    break;

                                default:
                                    break;
                            }
                        }
                    }
                    seqlog.TraceLog("File download Processs finish at = >" + DateTime.Now, FileName);
                    seqlog.TraceLog("====================================", FileName);
                    return true;
                }
                catch (Exception ex)
                {
                    seqlog.TraceLog("File download Processs fail at = >" + DateTime.Now, FileName);
                    seqlog.TraceLog("Err Desc = > " + ex.Message, FileName);
                    seqlog.TraceLog("====================================", FileName);
                    return false;
                }

                #endregion Copy MPU...
            }
        }

        /// <summary>
        /// DOWNLOAD FILES FROM MPU FTP SERVER
        /// </summary>
        /// <param name="downloadpath">Source Path</param>
        /// <param name="UserName">FTP Username</param>
        /// <param name="Password">FTP Password</param>
        /// <param name="localpath">Destination Path</param>
        private void DownloadFromFTPServer(string downloadpath, string UserName, string Password, string localpath)
        {
            FTPclient _FTPClinet = new FTPclient(downloadpath, UserName, Password);
            _FTPClinet.CurrentDirectory = "/";
            SetFTPClient(_FTPClinet, localpath);
        }

        /***
         * GET THE SUB FOLDER NAME OF PATH
        ***/

        private string getLastPath(string path)
        {
            string[] splitForPath = path.Split('\\');
            string lastPath = splitForPath[splitForPath.Length - 2];
            return lastPath;
        }

        private FTPclient MainClient;

        private void SetFTPClient(FTP.Library.FTPclient client, string localpath)
        {
            SequenceLog SeqLog = new SequenceLog();
            SeqLog.TraceLog("Start download from = > " + client.Hostname + " start at = > " + DateTime.Now, this.FileName);
            MainClient = client;
            MainClient.OnNewMessageReceived += new FTPclient.NewMessageHandler(FtpClient_OnNewMessageReceived);
            foreach (FTPfileInfo _downloadFile in MainClient.ListDirectoryDetail("/"))
            {
                try
                {
                    MainClient.CurrentDirectory = "/";
                    MainClient.OnDownloadProgressChanged += new FTPclient.DownloadProgressChangedHandler(FtpClient_OnDownloadProgressChanged);
                    MainClient.OnDownloadCompleted += new FTPclient.DownloadCompletedHandler(FtpClient_OnDownloadCompleted);
                    MainClient.Download(_downloadFile.Filename, localpath + "\\" + _downloadFile.Filename, true);
                }
                catch (Exception ex)
                {
                    SeqLog.TraceLog("download fail for = > " + _downloadFile.Filename + " at = > " + DateTime.Now, this.FileName);
                    SeqLog.TraceLog("Err Desc = > " + ex.Message, this.FileName);
                }
            }
            SeqLog.TraceLog("Download Finish at = > " + DateTime.Now, this.FileName);
        }

        private void FtpClient_OnDownloadProgressChanged(object sender, DownloadProgressChangedArgs e)
        {
        }

        private void FtpClient_OnDownloadCompleted(object sender, DownloadCompletedArgs e)
        {
        }

        private void FtpClient_OnNewMessageReceived(object myObject, NewMessageEventArgs e)
        {
        }

        private void GetListDirectoryFromFTP(string downloadpath, string UserName, string Password, string localfilepath)
        {
            DMLStringExecuterController DMLCtrl = new DMLStringExecuterController();
            DataTable dt = DMLCtrl.DMLStringExecuter("select convert(char(10),SYSDate,102) AS SYSDate from sys001 where name = 'LAST_DAYEND_DATE'");
            if (dt.Rows.Count < 0) return;

            string downloaddate = Convert.ToString(dt.Rows[0]["SYSDate"]);
            downloaddate = downloaddate.Substring(0, 4) + downloaddate.Substring(5, 2) + downloaddate.Substring(8, 2);

            FtpWebRequest request = (FtpWebRequest)WebRequest.Create(downloadpath);
            request.Method = WebRequestMethods.Ftp.ListDirectoryDetails;

            // This example assumes the FTP site uses anonymous logon.
            request.Credentials = new NetworkCredential(UserName, Password);

            FtpWebResponse response = (FtpWebResponse)request.GetResponse();

            Stream responseStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(responseStream);
            string dir = reader.ReadToEnd();
            FTPfileInfo _FtpFileInfo;

            foreach (string line in dir.Replace("\n", "").Split(System.Convert.ToChar('\r')))
            {
                //parse
                if (line != "")
                {
                    _FtpFileInfo = new FTPfileInfo(line, "/");
                    string _filename = _FtpFileInfo.Filename;
                    FTPclient ftp = new FTPclient(downloadpath, UserName, Password);
                    ftp.CurrentDirectory = "/";
                    ftp.Download(_FtpFileInfo, localfilepath + _FtpFileInfo.Filename + "\\", true);
                }
              
            }
            reader.Close();
            response.Close();
        }

        /// <summary>
        /// Download files with the given schedule time...
        /// </summary>
        private void DownloadScheduleWaiting()
        {
            try
            {
                while (true)
                {
                    if (Convert.ToInt16(downloadtime.Split(':')[0]) == DateTime.Now.Hour &&
                        Convert.ToInt16(downloadtime.Split(':')[1]) == DateTime.Now.Minute)
                    {
                        ConfigChanger();
                        StartDownload();
                        WritetoLog();
                        return;
                    }
                    /*** THIS CODE MUST HAVE TO REMOVE IN REAL CONDITION ***/
                    else
                    {
                        ConfigChanger();
                        StartDownload();
                        WritetoLog();
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// Writing SequenceLog and reading settlement files, parsing and inserting into database etc...
        /// </summary>
        private void WritetoLog()
        {
            SequenceLog Seqlog = new SequenceLog();
            try
            {
                DateTime STFDate;
                SettlementFileReading(out STFDate);
                CoreBankingSettlementFileDownload(STFDate);
                Seqlog.TraceLog("Log Writing Event Start at = > " + DateTime.Now, FileName);
                Seqlog.TraceLog("Log Writing Event Finish at = > " + DateTime.Now, FileName);
            }
            catch (Exception ex)
            {
                Seqlog.TraceLog("Log Writing Event Fail at = >" + DateTime.Now, FileName);
                Seqlog.TraceLog("Err Desc = > " + ex.Message, FileName);
            }
        }

        /// <summary>
        /// Database configuration
        /// </summary>
        private void ConfigChanger()
        {
            SequenceLog Seqlog = new SequenceLog();
            try
            {
                string HostPort = string.Empty;
                string DBName = string.Empty;
                string DBUserName = string.Empty;
                string DBPassword = string.Empty;
                string ServerName = string.Empty;

                Seqlog.TraceLog("Config Writing Event Start at = >" + DateTime.Now, FileName);

                DataRetriveFromReg dreg = new DataRetriveFromReg();
                AppConfigInfo.RegDataSuit = dreg.ServerConfigRetrieve();

                AppConfigInfo.RegDataSuit.Reset();
                while (AppConfigInfo.RegDataSuit.MoveNext())
                    switch (AppConfigInfo.RegDataSuit.Key.ToString())
                    {
                        case "DBName":
                            DBName = Convert.ToString(AppConfigInfo.RegDataSuit.Value);
                            break;

                        case "DBUserName":
                            DBUserName = Convert.ToString(AppConfigInfo.RegDataSuit.Value);
                            break;

                        case "DBPassword":
                            DBPassword = Convert.ToString(AppConfigInfo.RegDataSuit.Value);
                            break;

                        case "ServerName":
                            ServerName = Convert.ToString(AppConfigInfo.RegDataSuit.Value);
                            break;

                        default:
                            break;
                    }
                ConfigWriter cfw = new ConfigWriter();
                cfw.DBConnectionstringWriter("SettlementDB", ServerName, DBName, DBUserName, DBPassword);
                Seqlog.TraceLog("Config Writing Event Finish at = >" + DateTime.Now, FileName);
            }
            catch (Exception ex)
            {
                Seqlog.TraceLog("Config Writing Event Fail at = >" + DateTime.Now, FileName); 
                Seqlog.TraceLog("Err Desc = > " + ex.Message, FileName);
            }
        }

        /// <summary>
        /// SettlementFileReading
        /// </summary>
        /// <param name="STFDate" type="DateTime">DateTime will be return as Output Param</param>
        private void SettlementFileReading(out DateTime STFDate)
        {
            SequenceLog SeqLog = new SequenceLog();
            STFDate = DateTime.Now;

            ///<comment>
            /// ENHANCE PROPERTIES FOR E-COMMERCE
            ///</comment>
            string subFolder = "ECOM";
            string MerchantEcommercePath = MerchantStFile + Path.DirectorySeparatorChar + subFolder;
            //string MemberEcommercePath = MemberBankSTF + Path.DirectorySeparatorChar + subFolder;
            string MerchantTrailEcommercePath = MerchantTrailFilePath + Path.DirectorySeparatorChar + subFolder;
            string MemberTrailEcommercePath = MemberTrailFilePath + Path.DirectorySeparatorChar + subFolder;

            StreamReader Stw;

            try
            {
                SeqLog.TraceLog("SettlementFileReading Event Start at = >" + DateTime.Now, FileName);

                ///<summary>
                /// Reading Merchant Files from MPU. (MCC)
                ///</summary>
                string[] MerchantSTFtNameSuit = Directory.GetFiles(MerchantStFile);
                for (int i = 0; i < MerchantSTFtNameSuit.Length; i++)
                {
                    SeqLog.TraceLog("Merchant Settlement File " + MerchantSTFtNameSuit[i] + "Reading Start at = > " + DateTime.Now, FileName);
                    Stw = new StreamReader(MerchantSTFtNameSuit[i]);
                    MerchantSettlementProcess(Stw, MerchantSTFtNameSuit[i].Replace(MerchantStFile + "\\", ""), out STFDate);
                    SeqLog.TraceLog("Merchant Settlement File " + MerchantSTFtNameSuit[i] + "Reading finish at = > " + DateTime.Now, FileName);
                }

                ///<summary>
                /// Reading Merchant E-Commerce Files from MPU\DateTime.Now. (MCC)
                ///</summary>
                string[] MerchantEcommerceNameSuit = Directory.GetFiles(MerchantEcommercePath);
                for (int i = 0; i < MerchantEcommerceNameSuit.Length; i++)
                {
                    SeqLog.TraceLog("Merchant E-Commerce Settlement File " + MerchantEcommerceNameSuit[i] + "Reading Start at = > " + DateTime.Now, FileName);
                    Stw = new StreamReader(MerchantEcommerceNameSuit[i]);

                    MerchantSettlementProcess(Stw, MerchantEcommerceNameSuit[i].Replace(MerchantEcommercePath + "\\", ""), out STFDate);
                    SeqLog.TraceLog("Merchant E-Commerce Settlement File " + MerchantEcommerceNameSuit[i] + "Reading finish at = > " + DateTime.Now, FileName);
                }

                ///<summary>
                /// Reading Member Bank Files from MPU. (INC)
                ///</summary>
                string[] MemberBankSTFNameSuit = Directory.GetFiles(MemberBankSTF);
                for (int i = 0; i < MemberBankSTFNameSuit.Length; i++)
                {
                    SeqLog.TraceLog("Member Bank Settlement File " + MemberBankSTFNameSuit[i] + "Reading Start at = > " + DateTime.Now, FileName);
                    Stw = new StreamReader(MemberBankSTFNameSuit[i]);
                    MemberBankSettlementProcess(Stw, MemberBankSTFNameSuit[i].Replace(MemberBankSTF + "\\", ""), out STFDate);
                    SeqLog.TraceLog("Member Bank Settlement File " + MemberBankSTFNameSuit[i] + "Reading finish at = > " + DateTime.Now, FileName);
                }

                
                ///<summary>
                /// Reading Merchant Trail File from MPU. (MCD)
                ///</summary>
                string[] MerchantTrailFile = Directory.GetFiles(MerchantTrailFilePath);
                for (int i = 0; i < MerchantTrailFile.Length; i++)
                {
                    SeqLog.TraceLog("Merchant Trail File " + MerchantTrailFile[i] + "Reading Start at = > " + DateTime.Now, FileName);
                    Stw = new StreamReader(MerchantTrailFile[i]);
                    MerchantTrailFileProcess(Stw, MerchantTrailFile[i].Replace(MerchantTrailFilePath + "\\", ""));
                    SeqLog.TraceLog("Merchant Trail File " + MerchantTrailFile[i] + "Reading finish at = > " + DateTime.Now, FileName);
                }

                ///<summary>
                /// Reading Merchant E-Commerce Trail File from MPU\DATETIME.NOW (MCD)
                ///</summary>
                string[] MerchantEcommTrailFileSuit = Directory.GetFiles(MerchantTrailEcommercePath);
                for (int i = 0; i < MerchantEcommTrailFileSuit.Length; i++)
                {
                    SeqLog.TraceLog("Merchant E-Commerce Trail File " + MerchantEcommTrailFileSuit[i] + "Reading Start at = > " + DateTime.Now, FileName);
                    Stw = new StreamReader(MerchantEcommTrailFileSuit[i]);
                    MerchantTrailFileProcess(Stw, MerchantEcommTrailFileSuit[i].Replace(MerchantTrailEcommercePath + "\\", ""));
                    SeqLog.TraceLog("Merchant E-Commerce Trail File " + MerchantEcommTrailFileSuit[i] + "Reading finish at = > " + DateTime.Now, FileName);
                }

                ///<summary>
                /// Reading Member Bank Trail File from MPU. (IND)
                ///</summary>
                string[] MemberBankTrailFile = Directory.GetFiles(MemberTrailFilePath);
                for (int i = 0; i < MemberBankTrailFile.Length; i++)
                {
                    SeqLog.TraceLog("MemberBank Trail File " + MemberBankTrailFile[i] + "Reading Start at = > " + DateTime.Now, FileName);
                    Stw = new StreamReader(MemberBankTrailFile[i]);
                    MemberBankTrailFileProcess(Stw, MemberBankTrailFile[i].Replace(MemberTrailFilePath + "\\", ""));
                    SeqLog.TraceLog("MemberBank Trail File " + MemberBankTrailFile[i] + "Reading finish at = > " + DateTime.Now, FileName);
                }

                
                ///<summary>
                /// Reading Master T464 File from MPU. (...)
                ///</summary>
                string[] MasterT464File = Directory.GetFiles(MasterT464FilePath);
                for (int i = 0; i < MasterT464File.Length; i++)
                {
                    SeqLog.TraceLog("MemberBank Trail File " + MasterT464File[i] + "Reading Start at = > " + DateTime.Now, FileName);
                    Stw = new StreamReader(MasterT464File[i]);
                    MasterT464FileProcess(Stw, MasterT464File[i].Replace(MasterT464FilePath + "\\", ""));
                    SeqLog.TraceLog("MemberBank Trail File " + MasterT464File[i] + "Reading finish at = > " + DateTime.Now, FileName);
                }
                SeqLog.TraceLog("SettlementFileReading Event Finish at = >" + DateTime.Now, FileName);
            }
            catch (Exception ex)
            {
                SeqLog.TraceLog("SettlementFileReading Event Fail at = >" + DateTime.Now, FileName);
                SeqLog.TraceLog("Err Desc = >" + ex.Message, FileName);
            }
        }

        /// <summary>
        /// MemberBankTrailFileProcess
        /// </summary>
        /// <param name="stw" type="StreamReader"></param>
        /// <param name="STFFileName" type="string"></param>
        ///

        private void MemberBankTrailFileProcess(StreamReader stw, string STFFileName)
        {
            SequenceLog SeqLog = new SequenceLog();
            MemberBankDetailTransactionInfoController MemberBankTranCtrl = new MemberBankDetailTransactionInfoController();
            MemberBankDetailTransactionInfoCollections MemberBankTranColl = new MemberBankDetailTransactionInfoCollections();
            MemberBankDetailTransactionInfoInfo MemberBankTranInfo;
            try
            {
                SeqLog.TraceLog("===================================", FileName);
                SeqLog.TraceLog("MemberBank Trail File Reading One By One start at = > " + DateTime.Now, FileName);
                MemberBankTranInfo = new MemberBankDetailTransactionInfoInfo();

                DMLStringExecuterController DMLCtrl = new DMLStringExecuterController();
                DataTable dml = DMLCtrl.DMLStringExecuter("DELETE FROM MEMBERBANKDETAILTRANSACTIONINFO WHERE FILENAME = '" + STFFileName + "'");

                if (STFFileName.Contains("INC")) //Read data for Ecom and Pos files
                {
                    while (!stw.EndOfStream)
                    {
                        string OneLine = stw.ReadLine();
                        string rescode = OneLine.Substring(0, 3).Trim();
                        int startpoint = 0;
                        if (OneLine.Trim() != string.Empty)
                        {
                            if (rescode == "000" || rescode == "001")
                            {
                                continue;
                            }
                            else
                            {
                                SeqLog.TraceLog("data = > " + OneLine, FileName);
                                MemberBankTranInfo.TranRespCode = Convert.ToString(OneLine.Substring(startpoint, MemberBankTranInfo.TranRespCodeLength)).Trim();
                                startpoint = startpoint + MemberBankTranInfo.TranRespCodeLength;
                                MemberBankTranInfo.PAN = Convert.ToString(OneLine.Substring(startpoint, MemberBankTranInfo.PANLength)).Trim();
                                startpoint = startpoint + MemberBankTranInfo.PANLength;
                                MemberBankTranInfo.ProcessingCode = Convert.ToString(OneLine.Substring(startpoint, MemberBankTranInfo.ProcessingCodeLenth));
                                startpoint = startpoint + MemberBankTranInfo.ProcessingCodeLenth;
                                MemberBankTranInfo.transAmount = Convert.ToDecimal(OneLine.Substring(startpoint, MemberBankTranInfo.TransAmountLength));
                                startpoint = startpoint + MemberBankTranInfo.TransAmountLength;
                                MemberBankTranInfo.settlementAmount = Convert.ToDecimal(OneLine.Substring(startpoint, MemberBankTranInfo.SettlementAmountLength));
                                startpoint = startpoint + MemberBankTranInfo.SettlementAmountLength;
                                MemberBankTranInfo.SetConservationRate = Convert.ToString(OneLine.Substring(startpoint, MemberBankTranInfo.SetConservationRateLength));
                                startpoint = startpoint + MemberBankTranInfo.SetConservationRateLength;
                                MemberBankTranInfo.TransactionCurCode = Convert.ToString(OneLine.Substring(startpoint, MemberBankTranInfo.TransactionCurcodelength));
                                startpoint = startpoint + MemberBankTranInfo.TransactionCurcodelength;
                                MemberBankTranInfo.SettlementCurcode = Convert.ToString(OneLine.Substring(startpoint, MemberBankTranInfo.SettlementCurcodelength));
                                startpoint = startpoint + MemberBankTranInfo.SettlementCurcodelength;
                                MemberBankTranInfo.TransDateTime = Convert.ToString(OneLine.Substring(startpoint, MemberBankTranInfo.TransDateTimeLength)).Trim();
                                startpoint = startpoint + MemberBankTranInfo.TransDateTimeLength;
                                MemberBankTranInfo.SystemTraceNo = Convert.ToString(OneLine.Substring(startpoint, MemberBankTranInfo.SystemTraceNoLength)).Trim();
                                startpoint = startpoint + MemberBankTranInfo.SystemTraceNoLength;
                                MemberBankTranInfo.AuthResponseCode = Convert.ToString(OneLine.Substring(startpoint, MemberBankTranInfo.AuthResponseCodeLength));
                                startpoint = startpoint + MemberBankTranInfo.AuthResponseCodeLength;
                                MemberBankTranInfo.AuthDate = Convert.ToString(OneLine.Substring(startpoint, MemberBankTranInfo.AuthDateLength));
                                startpoint = startpoint + MemberBankTranInfo.AuthDateLength;
                                MemberBankTranInfo.RetrievalRefNo = Convert.ToString(OneLine.Substring(startpoint, MemberBankTranInfo.RetrievalRefNoLength));
                                startpoint = startpoint + MemberBankTranInfo.RetrievalRefNoLength;
                                MemberBankTranInfo.AcquringInstitutionID = Convert.ToString(OneLine.Substring(startpoint, MemberBankTranInfo.AcquireInstitutionIDLength)).Trim();
                                startpoint = startpoint + MemberBankTranInfo.AcquireInstitutionIDLength;
                                MemberBankTranInfo.ForwardInstitutionID = Convert.ToString(OneLine.Substring(startpoint, MemberBankTranInfo.ForwardInstitutionIDLength)).Trim();
                                startpoint = startpoint + MemberBankTranInfo.ForwardInstitutionIDLength;
                                MemberBankTranInfo.MerchantType = Convert.ToString(OneLine.Substring(startpoint, MemberBankTranInfo.MerchantTypeLength));
                                startpoint = startpoint + MemberBankTranInfo.MerchantTypeLength;
                                MemberBankTranInfo.CardAcceptorTerminalNo = Convert.ToString(OneLine.Substring(startpoint, MemberBankTranInfo.CardAcceptorTerminalNoLength));
                                startpoint = startpoint + MemberBankTranInfo.CardAcceptorTerminalNoLength;
                                MemberBankTranInfo.CardAcceptorIDCode = Convert.ToString(OneLine.Substring(startpoint, MemberBankTranInfo.CardAcceptorIDCodeLength));
                                startpoint = startpoint + MemberBankTranInfo.CardAcceptorIDCodeLength;
                                MemberBankTranInfo.CardAcceptorName = Convert.ToString(OneLine.Substring(startpoint, MemberBankTranInfo.CardAcceptorNameLength));
                                startpoint = startpoint + MemberBankTranInfo.CardAcceptorNameLength;
                                MemberBankTranInfo.OrgTranInformation = Convert.ToString(OneLine.Substring(startpoint, MemberBankTranInfo.OrgTranInformationLength));
                                startpoint = startpoint + MemberBankTranInfo.OrgTranInformationLength;
                                MemberBankTranInfo.MessageType = Convert.ToString(OneLine.Substring(startpoint, MemberBankTranInfo.MessageTypeLength));
                                startpoint = startpoint + MemberBankTranInfo.MessageTypeLength;
                                MemberBankTranInfo.RecInstitutionID = Convert.ToString(OneLine.Substring(startpoint, MemberBankTranInfo.RecInstitutionIDLength));
                                startpoint = startpoint + MemberBankTranInfo.RecInstitutionIDLength;
                                MemberBankTranInfo.IssInstitutionID = Convert.ToString(OneLine.Substring(startpoint, MemberBankTranInfo.IssInstitutionIDLength));
                                startpoint = startpoint + MemberBankTranInfo.IssInstitutionIDLength;
                                MemberBankTranInfo.TranFeatures = Convert.ToString(OneLine.Substring(startpoint, MemberBankTranInfo.TranFeaturesLength));
                                startpoint = startpoint + MemberBankTranInfo.TranFeaturesLength;
                                MemberBankTranInfo.POSConditionCode = Convert.ToString(OneLine.Substring(startpoint, MemberBankTranInfo.POSConditionCodeLength));
                                startpoint = startpoint + MemberBankTranInfo.POSConditionCodeLength;
                                MemberBankTranInfo.MerchantCountryCode = Convert.ToString(OneLine.Substring(startpoint, MemberBankTranInfo.MerchantCountryCodeLength));
                                startpoint = startpoint + MemberBankTranInfo.MerchantCountryCodeLength;
                                MemberBankTranInfo.AuthType = Convert.ToString(OneLine.Substring(startpoint, MemberBankTranInfo.AuthTypeLength));
                                startpoint = startpoint + MemberBankTranInfo.AuthTypeLength;
                                MemberBankTranInfo.ServiceFeeReceive = Convert.ToDecimal(OneLine.Substring(startpoint, MemberBankTranInfo.ServiceFeeReceiveLength));
                                startpoint = startpoint + MemberBankTranInfo.ServiceFeeReceiveLength;
                                MemberBankTranInfo.ServiceFeePayable = Convert.ToDecimal(OneLine.Substring(startpoint, MemberBankTranInfo.ServiceFeePayableLength));
                                startpoint = startpoint + MemberBankTranInfo.ServiceFeePayableLength;
                                MemberBankTranInfo.ReservedForUse = Convert.ToString(OneLine.Substring(startpoint));

                                //MemberBankTranInfo.SETTLEMENTDATE = Convert.ToDateTime(STFFileName.Substring(7, 2) + "/" + STFFileName.Substring(5, 2) + "/" + STFFileName.Substring(3, 2));
                                MemberBankTranInfo.SETTLEMENTDATE = Convert.ToDateTime(STFFileName.Substring(7, 2) + "/" + STFFileName.Substring(5, 2) + "/" + DateTime.Now.Year.ToString(),
                                    System.Globalization.CultureInfo.GetCultureInfo("hi-IN").DateTimeFormat);
                                clsGlobal.vSTFDate = MemberBankTranInfo.SETTLEMENTDATE;

                                MemberBankTranInfo.FILENAME = STFFileName;
                                if (STFFileName.Substring(9, 3) == "11C")
                                    MemberBankTranInfo.FileType = "MBI"; // Member Bank Ecom Issusing Transaction File
                                else if (STFFileName.Substring(9, 3) == "01C")
                                    MemberBankTranInfo.FileType = "MBA"; // Member Bank Acquiring Transaction File
                                else if (STFFileName.Substring(9, 3) == "11E")
                                    MemberBankTranInfo.FileType = "MBIErr"; // Member Bank Iss Ecom Err Transaction Err File
                                else if (MemberBankTranInfo.FileType == "BCOM")
                                    MemberBankTranInfo.FileType = "BCOM";
                                else if (STFFileName.Substring(9, 3) == "I")
                                    MemberBankTranInfo.FileType = "MBAErr"; // Member Bank Acq Ecom Err Transaction Err File
                                
                                MemberBankTranInfo.BatchNo = DateTime.Now.Day + DateTime.Now.Month + DateTime.Now.Year;
                                MemberBankTranInfo.CreatedDate = DateTime.Now;
                                MemberBankTranInfo.RefundStatus = "A";

                                if (!MemberBankTranCtrl.Add(MemberBankTranInfo))
                                    throw new Exception("Data Writing Fail.");
                            }
                        }
                    } //End of while loop
                }
                else //Read data for Acom and Icom ATM file
                {
                    while (!stw.EndOfStream)
                    {
                        string OneLine = stw.ReadLine();
                        string rescode = OneLine.Substring(0, 3).Trim();
                        int startpoint = 0;
                        if (OneLine.Trim() != string.Empty)
                        {
                            if (rescode == "000" || rescode == "001")
                            {
                                continue;
                            }
                            else
                            {
                                SeqLog.TraceLog("data = > " + OneLine, FileName);
                                MemberBankTranInfo.TranRespCode = Convert.ToString(OneLine.Substring(startpoint, MemberBankTranInfo.TranRespCodeLength)).Trim();
                                startpoint = startpoint + MemberBankTranInfo.TranRespCodeLength;
                                MemberBankTranInfo.PAN = Convert.ToString(OneLine.Substring(startpoint, MemberBankTranInfo.PANLength)).Trim();
                                startpoint = startpoint + MemberBankTranInfo.PANLength;
                                MemberBankTranInfo.ProcessingCode = Convert.ToString(OneLine.Substring(startpoint, MemberBankTranInfo.ProcessingCodeLenth));
                                startpoint = startpoint + MemberBankTranInfo.ProcessingCodeLenth;
                                MemberBankTranInfo.transAmount = Convert.ToDecimal(OneLine.Substring(startpoint, MemberBankTranInfo.TransAmountLength));
                                startpoint = startpoint + MemberBankTranInfo.TransAmountLength;
                                MemberBankTranInfo.settlementAmount = Convert.ToDecimal(OneLine.Substring(startpoint, MemberBankTranInfo.SettlementAmountLength));
                                startpoint = startpoint + MemberBankTranInfo.SettlementAmountLength;
                                MemberBankTranInfo.SetConservationRate = Convert.ToString(OneLine.Substring(startpoint, MemberBankTranInfo.SetConservationRateLength));
                                startpoint = startpoint + MemberBankTranInfo.SetConservationRateLength;
                                startpoint += 1; //for ('/') filters
                                MemberBankTranInfo.SystemTraceNo = Convert.ToString(OneLine.Substring(startpoint, MemberBankTranInfo.SystemTraceNoLength)).Trim();
                                startpoint = startpoint + MemberBankTranInfo.SystemTraceNoLength;
                                startpoint += 1; //for ('/') filter
                                MemberBankTranInfo.TransDateTime = Convert.ToString(OneLine.Substring(startpoint, MemberBankTranInfo.TransDateTimeLength)).Trim();
                                startpoint = startpoint + MemberBankTranInfo.TransDateTimeLength;

                                //MemberBankTranInfo.SETTLEMENTDATE = Convert.ToDateTime(STFFileName.Substring(7, 2) + "/" + STFFileName.Substring(5, 2) + "/" + STFFileName.Substring(3, 2));

                               
                                MemberBankTranInfo.SETTLEMENTDATE = Convert.ToDateTime(STFFileName.Substring(7, 2) + "/" + STFFileName.Substring(5, 2) + "/" + DateTime.Now.Year.ToString(), 
                                    System.Globalization.CultureInfo.GetCultureInfo("hi-IN").DateTimeFormat);

                                

                                clsGlobal.vSTFDate = MemberBankTranInfo.SETTLEMENTDATE;
                                startpoint = startpoint + 4;
                                //Terminal Type=Merchant Type
                                MemberBankTranInfo.MerchantType = Convert.ToString(OneLine.Substring(startpoint, MemberBankTranInfo.MerchantTypeLength));
                                startpoint = startpoint + MemberBankTranInfo.MerchantTypeLength;
                               
                                MemberBankTranInfo.AcquringInstitutionID = Convert.ToString(OneLine.Substring(startpoint, MemberBankTranInfo.AcquireInstitutionIDLength)).Trim();
                                startpoint = startpoint + MemberBankTranInfo.AcquireInstitutionIDLength;
                                MemberBankTranInfo.IssuerBankCode = Convert.ToString(OneLine.Substring(startpoint, MemberBankTranInfo.IssuerBankcodeLength)).Trim();
                                startpoint = startpoint + MemberBankTranInfo.IssuerBankcodeLength;
                                MemberBankTranInfo.BeneficiaryBankCode = Convert.ToString(OneLine.Substring(startpoint, MemberBankTranInfo.BeneficiaryBankcodeLength)).Trim();
                                startpoint = startpoint + MemberBankTranInfo.BeneficiaryBankcodeLength;
                                MemberBankTranInfo.ForwardInstitutionID = Convert.ToString(OneLine.Substring(startpoint, MemberBankTranInfo.ForwardInstitutionIDLength)).Trim();
                                startpoint = startpoint + MemberBankTranInfo.ForwardInstitutionIDLength;
                                MemberBankTranInfo.AuthResponseCode = Convert.ToString(OneLine.Substring(startpoint, MemberBankTranInfo.AuthResponseCodeLength));
                                startpoint = startpoint + MemberBankTranInfo.AuthResponseCodeLength;
                                startpoint += 1; //for ('/') filter
                                MemberBankTranInfo.RetrievalRefNo = Convert.ToString(OneLine.Substring(startpoint, MemberBankTranInfo.RetrievalRefNoLength));
                                startpoint = startpoint + MemberBankTranInfo.RetrievalRefNoLength;
                                startpoint += 1; //for ('/') filter
                                MemberBankTranInfo.CardAcceptorTerminalNo = Convert.ToString(OneLine.Substring(startpoint, MemberBankTranInfo.CardAcceptorTerminalNoLength));
                                startpoint = startpoint + MemberBankTranInfo.CardAcceptorTerminalNoLength;
                                MemberBankTranInfo.TransactionCurCode = Convert.ToString(OneLine.Substring(startpoint, MemberBankTranInfo.TransactionCurcodelength));
                                startpoint = startpoint + MemberBankTranInfo.TransactionCurcodelength;
                                MemberBankTranInfo.SettlementCurcode = Convert.ToString(OneLine.Substring(startpoint, MemberBankTranInfo.SettlementCurcodelength));
                                startpoint = startpoint + MemberBankTranInfo.SettlementCurcodelength;
                                MemberBankTranInfo.FromAccount = Convert.ToString(OneLine.Substring(startpoint, MemberBankTranInfo.FromAccountlength));
                                startpoint = startpoint + MemberBankTranInfo.FromAccountlength;
                                MemberBankTranInfo.ToAccount = Convert.ToString(OneLine.Substring(startpoint, MemberBankTranInfo.ToAccountlength));
                                startpoint = startpoint + MemberBankTranInfo.ToAccountlength;
                                MemberBankTranInfo.MessageType = Convert.ToString(OneLine.Substring(startpoint, MemberBankTranInfo.MessageTypeLength));
                                startpoint = startpoint + MemberBankTranInfo.MessageTypeLength;
                                MemberBankTranInfo.ResponseCode = Convert.ToString(OneLine.Substring(startpoint, MemberBankTranInfo.ResponseCodeLength));
                                startpoint = startpoint + MemberBankTranInfo.ResponseCodeLength;
                                MemberBankTranInfo.ServiceFeeReceive = Convert.ToDecimal(OneLine.Substring(startpoint, MemberBankTranInfo.ServiceFeeReceiveLength));
                                startpoint = startpoint + MemberBankTranInfo.ServiceFeeReceiveLength;
                                MemberBankTranInfo.ServiceFeePayable = Convert.ToDecimal(OneLine.Substring(startpoint, MemberBankTranInfo.ServiceFeePayableLength));
                                startpoint = startpoint + MemberBankTranInfo.ServiceFeePayableLength;
                                MemberBankTranInfo.InterChangeServiceFee = Convert.ToDecimal(OneLine.Substring(startpoint, MemberBankTranInfo.InterChangeServiceFeeLength));
                                startpoint = startpoint + MemberBankTranInfo.InterChangeServiceFeeLength;
                                MemberBankTranInfo.POSEntryMode = Convert.ToString(OneLine.Substring(startpoint, MemberBankTranInfo.POSEntryModeLength));
                                startpoint = startpoint + MemberBankTranInfo.POSEntryModeLength;
                                MemberBankTranInfo.OrgSystemTraceNo = Convert.ToString(OneLine.Substring(startpoint, MemberBankTranInfo.OrgSystemTraceNolength));
                                startpoint = startpoint + MemberBankTranInfo.OrgSystemTraceNolength;
                                MemberBankTranInfo.POSConditionCode = Convert.ToString(OneLine.Substring(startpoint, MemberBankTranInfo.POSConditionCodeLength));
                                startpoint = startpoint + MemberBankTranInfo.POSConditionCodeLength;
                                MemberBankTranInfo.CardAcceptorIDCode = Convert.ToString(OneLine.Substring(startpoint, MemberBankTranInfo.CardAcceptorIDCodeLength));
                                startpoint = startpoint + MemberBankTranInfo.CardAcceptorIDCodeLength;
                                MemberBankTranInfo.AcceptanceAmount = Convert.ToDecimal(OneLine.Substring(startpoint, MemberBankTranInfo.AcceptanceAmountLength));
                                startpoint = startpoint + MemberBankTranInfo.AcceptanceAmountLength;

                                MemberBankTranInfo.CardHolderTransType = Convert.ToString(OneLine.Substring(startpoint, MemberBankTranInfo.CardHolderTransTypeLenght));
                                startpoint = startpoint + MemberBankTranInfo.CardHolderTransTypeLenght;


                                MemberBankTranInfo.CardHolderTransFee = Convert.ToDecimal(OneLine.Substring(startpoint, MemberBankTranInfo.CardHolderTransFeeLength))/100;
                                startpoint = startpoint + MemberBankTranInfo.CardHolderTransFeeLength;

                                MemberBankTranInfo.TranTranmissionDate = Convert.ToString(OneLine.Substring(startpoint, MemberBankTranInfo.TranTranmissionDateLength));
                                startpoint = startpoint + MemberBankTranInfo.TranTranmissionDateLength;
                                MemberBankTranInfo.RefundStatus = "A";

                                
                                MemberBankTranInfo.ReservedForUse = Convert.ToString(OneLine.Substring(startpoint));
                                MemberBankTranInfo.FILENAME = STFFileName;
                                if (STFFileName.Substring(11, 1) == "I" && STFFileName.Substring(12, 3) == "COM")
                                    MemberBankTranInfo.FileType = "MBI"; // Member Bank Issuing Transaction File
                                else if (STFFileName.Substring(11, 1) == "A" && STFFileName.Substring(12, 3) == "COM")
                                    MemberBankTranInfo.FileType = "MBA"; // Member Bank Acquiring Transaction File
                                else if (STFFileName.Substring(11, 1) == "A" && STFFileName.Substring(12, 3) == "ERR")
                                    MemberBankTranInfo.FileType = "MBAE"; // Member Bank Acquiring Transaction Err File
                                else if (STFFileName.Substring(11, 1) == "I" && STFFileName.Substring(12, 3) == "ERR")
                                    MemberBankTranInfo.FileType = "MBIE"; // Member Bank Issuing Transaction Err File
                                else if (STFFileName.Substring(11, 1) == "B" && STFFileName.Substring(12, 3) == "COM")
                                    MemberBankTranInfo.FileType = "BCOM";
                                MemberBankTranInfo.BatchNo = DateTime.Now.Day + DateTime.Now.Month + DateTime.Now.Year;
                                MemberBankTranInfo.CreatedDate = DateTime.Now;

                                if (!MemberBankTranCtrl.Add(MemberBankTranInfo))
                                    throw new Exception("Data Writing Fail.");
                            }
                        }
                    } //End of while loop
                } //End of else loop

               
                SeqLog.TraceLog("MemberBank Trail File Reading One By One finish at = > " + DateTime.Now, FileName);
                SeqLog.TraceLog("===================================", FileName);
            }
            catch (Exception ex)
            {
                SeqLog.TraceLog("MemberBank Trail File Reading One By One fail at = > " + DateTime.Now, FileName);
                SeqLog.TraceLog("Err Desc = > " + ex.Message, FileName);
                SeqLog.TraceLog("===================================", FileName);
            }
        }

        /// <summary>
        /// MasterT464FileProcess
        /// </summary>
        /// <param name="stw"></param>
        /// <param name="STFFileName"></param>
        private void MasterT464FileProcess(StreamReader stw, string STFFileName)
        {
            SequenceLog SeqLog = new SequenceLog();
            string MsgTypeInd = string.Empty;
            string SwitchSrNo = string.Empty;
            string TransType = string.Empty;
            string ProcessID = string.Empty;
            string TransDate = string.Empty;
            string TransTime = string.Empty;
            string PANLenght = string.Empty;
            string PANumber = string.Empty;
            string PrccCode = string.Empty;
            string TraceNo = string.Empty;
            string MCCType = string.Empty;
            string POSEntry = string.Empty;
            string RefNo = string.Empty;
            string AcqID = string.Empty;
            string TerminalID = string.Empty;
            string RespCode = string.Empty;
            string Brand = string.Empty;
            string AdvRCode = string.Empty;
            string IntraCurCode = string.Empty;
            string AuthID = string.Empty;
            string CurrCodeTran = string.Empty;
            string ImpDecTran = string.Empty;
            string CompAmtTran = string.Empty;
            string CompAmtTranSign = string.Empty;
            string CashBackAmtL = string.Empty;
            string CashBackAmtLSign = string.Empty;
            string AccessFeeL = string.Empty;
            string AccessFeeLSign = string.Empty;
            string CurCodeSTF = string.Empty;
            string ImpDSTF = string.Empty;
            string CovRateSTF = string.Empty;
            string ComAmtSTF = string.Empty;
            string ComAmtSTFSign = string.Empty;
            string IntChangeFee = string.Empty;
            string IntChangeFeeSign = string.Empty;
            string SvcLevelInd = string.Empty;
            string ResponseCode = string.Empty;
            string PostIDInd = string.Empty;
            string ATMSChangeFeePID = string.Empty;
            string CBorderIndcator = string.Empty;
            string CBorderCurIndcator = string.Empty;
            string VISAISAFeeIndcator = string.Empty;
            string ReqAmtTranLocal = string.Empty;
            string TraceNAdjTrans = string.Empty;
            DMLStringExecuterController DMLCtrl = new DMLStringExecuterController();
            DMLCtrl.DMLStringExecuter("DELETE FROM MasterT464NREC_Info");
            try
            {
                SeqLog.TraceLog("===================================", FileName);
                SeqLog.TraceLog("Master T464 File Reading One By One start at = > " + DateTime.Now, FileName);

                while (!stw.EndOfStream)
                {
                    string OneLine = stw.ReadLine();
                    int startpoint = 0;
                    if (OneLine.Trim() != string.Empty)
                    {
                        MsgTypeInd = string.Empty;
                        SwitchSrNo = string.Empty;
                        TransType = string.Empty;
                        ProcessID = string.Empty;
                        TransDate = string.Empty;
                        TransTime = string.Empty;
                        PANLenght = string.Empty;
                        PANumber = string.Empty;
                        PrccCode = string.Empty;
                        TraceNo = string.Empty;
                        MCCType = string.Empty;
                        POSEntry = string.Empty;
                        RefNo = string.Empty;
                        AcqID = string.Empty;
                        TerminalID = string.Empty;
                        RespCode = string.Empty;
                        Brand = string.Empty;
                        AdvRCode = string.Empty;
                        IntraCurCode = string.Empty;
                        AuthID = string.Empty;
                        CurrCodeTran = string.Empty;
                        ImpDecTran = string.Empty;
                        CompAmtTran = string.Empty;
                        CompAmtTranSign = string.Empty;
                        CashBackAmtL = string.Empty;
                        CashBackAmtLSign = string.Empty;
                        AccessFeeL = string.Empty;
                        AccessFeeLSign = string.Empty;
                        CurCodeSTF = string.Empty;
                        ImpDSTF = string.Empty;
                        CovRateSTF = string.Empty;
                        ComAmtSTF = string.Empty;
                        ComAmtSTFSign = string.Empty;
                        IntChangeFee = string.Empty;
                        IntChangeFeeSign = string.Empty;
                        SvcLevelInd = string.Empty;
                        ResponseCode = string.Empty;
                        PostIDInd = string.Empty;
                        ATMSChangeFeePID = string.Empty;
                        CBorderIndcator = string.Empty;
                        CBorderCurIndcator = string.Empty;
                        VISAISAFeeIndcator = string.Empty;
                        ReqAmtTranLocal = string.Empty;
                        TraceNAdjTrans = string.Empty;

                        SeqLog.TraceLog("data = > " + OneLine, FileName);

                        MsgTypeInd = OneLine.Substring(0, 4);
                        SwitchSrNo = OneLine.Substring(4, 9);
                        TransType = OneLine.Substring(9 + 4, 1);
                        ProcessID = OneLine.Substring(9 + 4 + 1, 4);
                        TransDate = OneLine.Substring(9 + 4 + 1 + 4, 6);
                        TransTime = OneLine.Substring(9 + 4 + 1 + 4 + 6, 6);
                        PANLenght = OneLine.Substring(9 + 4 + 1 + 4 + 6 + 6, 2);
                        PANumber = OneLine.Substring(9 + 4 + 1 + 4 + 6 + 6 + 2, 19);
                        PrccCode = OneLine.Substring(9 + 4 + 1 + 4 + 6 + 6 + 2 + 19, 6);
                        TraceNo = OneLine.Substring(9 + 4 + 1 + 4 + 6 + 6 + 2 + 19 + 6, 6);
                        MCCType = OneLine.Substring(9 + 4 + 1 + 4 + 6 + 6 + 2 + 19 + 6 + 6, 4);
                        POSEntry = OneLine.Substring(9 + 4 + 1 + 4 + 6 + 6 + 2 + 19 + 6 + 6 + 4, 3);
                        RefNo = OneLine.Substring(9 + 4 + 1 + 4 + 6 + 6 + 2 + 19 + 6 + 6 + 4 + 3, 12);
                        AcqID = OneLine.Substring(9 + 4 + 1 + 4 + 6 + 6 + 2 + 19 + 6 + 6 + 4 + 3 + 12, 10);
                        TerminalID = OneLine.Substring(9 + 4 + 1 + 4 + 6 + 6 + 2 + 19 + 6 + 6 + 4 + 3 + 12 + 10, 10);
                        RespCode = OneLine.Substring(9 + 4 + 1 + 4 + 6 + 6 + 2 + 19 + 6 + 6 + 4 + 3 + 12 + 10 + 10, 2);
                        Brand = OneLine.Substring(9 + 4 + 1 + 4 + 6 + 6 + 2 + 19 + 6 + 6 + 4 + 3 + 12 + 10 + 10 + 2, 3);
                        AdvRCode = OneLine.Substring(9 + 4 + 1 + 4 + 6 + 6 + 2 + 19 + 6 + 6 + 4 + 3 + 12 + 10 + 10 + 2 + 3, 7);
                        IntraCurCode = OneLine.Substring(9 + 4 + 1 + 4 + 6 + 6 + 2 + 19 + 6 + 6 + 4 + 3 + 12 + 10 + 10 + 2 + 3 + 7, 4);
                        AuthID = OneLine.Substring(9 + 4 + 1 + 4 + 6 + 6 + 2 + 19 + 6 + 6 + 4 + 3 + 12 + 10 + 10 + 2 + 3 + 7 + 4, 6);
                        CurrCodeTran = OneLine.Substring(9 + 4 + 1 + 4 + 6 + 6 + 2 + 19 + 6 + 6 + 4 + 3 + 12 + 10 + 10 + 2 + 3 + 7 + 4 + 6, 3);
                        ImpDecTran = OneLine.Substring(9 + 4 + 1 + 4 + 6 + 6 + 2 + 19 + 6 + 6 + 4 + 3 + 12 + 10 + 10 + 2 + 3 + 7 + 4 + 6 + 3, 1);
                        CompAmtTran = OneLine.Substring(9 + 4 + 1 + 4 + 6 + 6 + 2 + 19 + 6 + 6 + 4 + 3 + 12 + 10 + 10 + 2 + 3 + 7 + 4 + 6 + 3 + 1, 12);
                        CompAmtTranSign = OneLine.Substring(9 + 4 + 1 + 4 + 6 + 6 + 2 + 19 + 6 + 6 + 4 + 3 + 12 + 10 + 10 + 2 + 3 + 7 + 4 + 6 + 3 + 1 + 12, 1);
                        CashBackAmtL = OneLine.Substring(9 + 4 + 1 + 4 + 6 + 6 + 2 + 19 + 6 + 6 + 4 + 3 + 12 + 10 + 10 + 2 + 3 + 7 + 4 + 6 + 3 + 1 + 12 + 1, 12);
                        CashBackAmtLSign = OneLine.Substring(9 + 4 + 1 + 4 + 6 + 6 + 2 + 19 + 6 + 6 + 4 + 3 + 12 + 10 + 10 + 2 + 3 + 7 + 4 + 6 + 3 + 1 + 12 + 1 + 12, 1);
                        AccessFeeL = OneLine.Substring(9 + 4 + 1 + 4 + 6 + 6 + 2 + 19 + 6 + 6 + 4 + 3 + 12 + 10 + 10 + 2 + 3 + 7 + 4 + 6 + 3 + 1 + 12 + 1 + 12 + 1, 8);
                        AccessFeeLSign = OneLine.Substring(9 + 4 + 1 + 4 + 6 + 6 + 2 + 19 + 6 + 6 + 4 + 3 + 12 + 10 + 10 + 2 + 3 + 7 + 4 + 6 + 3 + 1 + 12 + 1 + 12 + 1 + 8, 1);
                        CurCodeSTF = OneLine.Substring(9 + 4 + 1 + 4 + 6 + 6 + 2 + 19 + 6 + 6 + 4 + 3 + 12 + 10 + 10 + 2 + 3 + 7 + 4 + 6 + 3 + 1 + 12 + 1 + 12 + 1 + 8 + 1, 3);
                        ImpDSTF = OneLine.Substring(9 + 4 + 1 + 4 + 6 + 6 + 2 + 19 + 6 + 6 + 4 + 3 + 12 + 10 + 10 + 2 + 3 + 7 + 4 + 6 + 3 + 1 + 12 + 1 + 12 + 1 + 8 + 1 + 3, 1);
                        CovRateSTF = OneLine.Substring(9 + 4 + 1 + 4 + 6 + 6 + 2 + 19 + 6 + 6 + 4 + 3 + 12 + 10 + 10 + 2 + 3 + 7 + 4 + 6 + 3 + 1 + 12 + 1 + 12 + 1 + 8 + 1 + 3 + 1, 8);
                        ComAmtSTF = OneLine.Substring(9 + 4 + 1 + 4 + 6 + 6 + 2 + 19 + 6 + 6 + 4 + 3 + 12 + 10 + 10 + 2 + 3 + 7 + 4 + 6 + 3 + 1 + 12 + 1 + 12 + 1 + 8 + 1 + 3 + 1 + 8, 12);
                        ComAmtSTFSign = OneLine.Substring(9 + 4 + 1 + 4 + 6 + 6 + 2 + 19 + 6 + 6 + 4 + 3 + 12 + 10 + 10 + 2 + 3 + 7 + 4 + 6 + 3 + 1 + 12 + 1 + 12 + 1 + 8 + 1 + 3 + 1 + 8 + 12, 1);
                        IntChangeFee = OneLine.Substring(9 + 4 + 1 + 4 + 6 + 6 + 2 + 19 + 6 + 6 + 4 + 3 + 12 + 10 + 10 + 2 + 3 + 7 + 4 + 6 + 3 + 1 + 12 + 1 + 12 + 1 + 8 + 1 + 3 + 1 + 8 + 12 + 1, 10);
                        IntChangeFeeSign = OneLine.Substring(9 + 4 + 1 + 4 + 6 + 6 + 2 + 19 + 6 + 6 + 4 + 3 + 12 + 10 + 10 + 2 + 3 + 7 + 4 + 6 + 3 + 1 + 12 + 1 + 12 + 1 + 8 + 1 + 3 + 1 + 8 + 12 + 1 + 10, 1);
                        SvcLevelInd = OneLine.Substring(9 + 4 + 1 + 4 + 6 + 6 + 2 + 19 + 6 + 6 + 4 + 3 + 12 + 10 + 10 + 2 + 3 + 7 + 4 + 6 + 3 + 1 + 12 + 1 + 12 + 1 + 8 + 1 + 3 + 1 + 8 + 12 + 1 + 10 + 1, 3);
                        ResponseCode = OneLine.Substring(9 + 4 + 1 + 4 + 6 + 6 + 2 + 19 + 6 + 6 + 4 + 3 + 12 + 10 + 10 + 2 + 3 + 7 + 4 + 6 + 3 + 1 + 12 + 1 + 12 + 1 + 8 + 1 + 3 + 1 + 8 + 12 + 1 + 10 + 1 + 3, 2);
                        PostIDInd = OneLine.Substring(9 + 4 + 1 + 4 + 6 + 6 + 2 + 19 + 6 + 6 + 4 + 3 + 12 + 10 + 10 + 2 + 3 + 7 + 4 + 6 + 3 + 1 + 12 + 1 + 12 + 1 + 8 + 1 + 3 + 1 + 8 + 12 + 1 + 10 + 1 + 3 + 2 + 10, 1);
                        ATMSChangeFeePID = OneLine.Substring(9 + 4 + 1 + 4 + 6 + 6 + 2 + 19 + 6 + 6 + 4 + 3 + 12 + 10 + 10 + 2 + 3 + 7 + 4 + 6 + 3 + 1 + 12 + 1 + 12 + 1 + 8 + 1 + 3 + 1 + 8 + 12 + 1 + 10 + 1 + 3 + 2 + 10 + 1, 1);
                        CBorderIndcator = OneLine.Substring(9 + 4 + 1 + 4 + 6 + 6 + 2 + 19 + 6 + 6 + 4 + 3 + 12 + 10 + 10 + 2 + 3 + 7 + 4 + 6 + 3 + 1 + 12 + 1 + 12 + 1 + 8 + 1 + 3 + 1 + 8 + 12 + 1 + 10 + 1 + 3 + 2 + 10 + 1 + 1, 1);
                        CBorderCurIndcator = OneLine.Substring(9 + 4 + 1 + 4 + 6 + 6 + 2 + 19 + 6 + 6 + 4 + 3 + 12 + 10 + 10 + 2 + 3 + 7 + 4 + 6 + 3 + 1 + 12 + 1 + 12 + 1 + 8 + 1 + 3 + 1 + 8 + 12 + 1 + 10 + 1 + 3 + 2 + 10 + 1 + 1 + 1, 1);
                        VISAISAFeeIndcator = OneLine.Substring(9 + 4 + 1 + 4 + 6 + 6 + 2 + 19 + 6 + 6 + 4 + 3 + 12 + 10 + 10 + 2 + 3 + 7 + 4 + 6 + 3 + 1 + 12 + 1 + 12 + 1 + 8 + 1 + 3 + 1 + 8 + 12 + 1 + 10 + 1 + 3 + 2 + 10 + 1 + 1 + 1 + 1, 1);
                        ReqAmtTranLocal = OneLine.Substring(9 + 4 + 1 + 4 + 6 + 6 + 2 + 19 + 6 + 6 + 4 + 3 + 12 + 10 + 10 + 2 + 3 + 7 + 4 + 6 + 3 + 1 + 12 + 1 + 12 + 1 + 8 + 1 + 3 + 1 + 8 + 12 + 1 + 10 + 1 + 3 + 2 + 10 + 1 + 1 + 1 + 1 + 1, 12);
                        TraceNAdjTrans = OneLine.Substring(9 + 4 + 1 + 4 + 6 + 6 + 2 + 19 + 6 + 6 + 4 + 3 + 12 + 10 + 10 + 2 + 3 + 7 + 4 + 6 + 3 + 1 + 12 + 1 + 12 + 1 + 8 + 1 + 3 + 1 + 8 + 12 + 1 + 10 + 1 + 3 + 2 + 10 + 1 + 1 + 1 + 1 + 1 + 12 + 12, 6);
                        DMLCtrl = new DMLStringExecuterController();
                        DMLCtrl.DMLStringExecuter("INSERT INTO MasterT464NREC_Info VALUES('" + MsgTypeInd + "','" + SwitchSrNo + "','" + TransType + "'" +
                            ",'" + ProcessID + "','" + TransDate + "','" + TransTime + "','" + PANLenght + "','" + PANumber + "','" + PrccCode + "','" + TraceNo + "'" +
                            ",'" + MCCType + "','" + POSEntry + "','" + RefNo + "','" + AcqID + "','" + TerminalID + "','" + RespCode + "','" + Brand + "'" +
                            ",'" + AdvRCode + "','" + IntraCurCode + "','" + AuthID + "','" + CurrCodeTran + "','" + ImpDecTran + "','" + CompAmtTran + "','" + CompAmtTranSign + "'" +
                            ",'" + CashBackAmtL + "','" + CashBackAmtLSign + "','" + AccessFeeL + "','" + AccessFeeLSign + "','" + CurCodeSTF + "','" + ImpDSTF + "','" + CovRateSTF + "'" +
                            ",'" + ComAmtSTF + "','" + ComAmtSTFSign + "','" + IntChangeFee + "','" + IntChangeFeeSign + "','" + SvcLevelInd + "','" + ResponseCode + "','" + PostIDInd + "'" +
                            ",'" + ATMSChangeFeePID + "','" + CBorderIndcator + "','" + CBorderCurIndcator + "','" + VISAISAFeeIndcator + "','" + ReqAmtTranLocal + "','" + TraceNAdjTrans + "')");
                    }
                }

                SeqLog.TraceLog("Master T464 File Reading One By One finish at = > " + DateTime.Now, FileName);
                SeqLog.TraceLog("===================================", FileName);
            }
            catch (Exception ex)
            {
                SeqLog.TraceLog("Master T464 File Reading One By One fail at = > " + DateTime.Now, FileName);
                SeqLog.TraceLog("Err Desc = > " + ex.Message, FileName);
                SeqLog.TraceLog("===================================", FileName);
            }
        }

        /// <summary>
        /// Merchant Trail File Process
        /// </summary>
        /// <param name="Stw"></param>
        /// <param name="STFFileName"></param>
        private void MerchantTrailFileProcess(StreamReader Stw, string STFFileName)
        {
            SequenceLog SeqLog = new SequenceLog();
            MerchantDetailTransaction_InfoInfo MerchantTranInfo;
            MerchantDetailTransaction_InfoCollections MerchantTranColl = new MerchantDetailTransaction_InfoCollections();
            try
            {
                SeqLog.TraceLog("================================================ " + DateTime.Now, FileName);
                SeqLog.TraceLog("Merchant Trail File Reading one by one start at = > " + DateTime.Now, FileName);
                while (!Stw.EndOfStream)
                {
                    MerchantTranInfo = new MerchantDetailTransaction_InfoInfo();
                    string OneLine = Stw.ReadLine();
                    if (OneLine.Trim() != string.Empty)
                    {
                        SeqLog.TraceLog("data = > " + OneLine, FileName);
                        MerchantTranInfo.AcquireInstitutionID = Convert.ToDecimal(OneLine.Substring(0, 11).Trim());
                        MerchantTranInfo.ForwardingInstitutionID = Convert.ToDecimal(OneLine.Substring(12, 11).Trim());
                        MerchantTranInfo.SystemTraceNo = Convert.ToDecimal(OneLine.Substring(24, 6).Trim());
                        MerchantTranInfo.TranDateTime = Convert.ToDecimal(OneLine.Substring(31, 10).Trim());
                        MerchantTranInfo.PAN = Convert.ToDecimal(OneLine.Substring(42, 19).Trim());
                        MerchantTranInfo.TransactionAmount = Convert.ToDecimal(OneLine.Substring(62, 12).Trim());
                        MerchantTranInfo.AccptAmount = Convert.ToDecimal(OneLine.Substring(75, 12).Trim());
                        MerchantTranInfo.MerchantTranFee = Convert.ToDecimal(OneLine.Substring(88, 12).Trim());
                        MerchantTranInfo.MessageType = Convert.ToDecimal(OneLine.Substring(101, 4).Trim());
                        MerchantTranInfo.ProcessingCode = Convert.ToDecimal(OneLine.Substring(106, 6).Trim());
                        MerchantTranInfo.MerchantType = Convert.ToDecimal(OneLine.Substring(113, 4).Trim());
                        MerchantTranInfo.AcceptorTerminalID = OneLine.Substring(118, 8).Trim();
                        MerchantTranInfo.AcceptorID = OneLine.Substring(127, 15).Trim();
                        MerchantTranInfo.RetrievalReferenceNo = OneLine.Substring(143, 12).Trim();
                        MerchantTranInfo.POSConditionCode = Convert.ToDecimal(OneLine.Substring(156, 2).Trim());
                        MerchantTranInfo.AuthorizeResponseCode = OneLine.Substring(159, 6).Trim();
                        MerchantTranInfo.InstitutionCode = Convert.ToDecimal(OneLine.Substring(166, 11).Trim());
                        MerchantTranInfo.OrgTraceNo = Convert.ToDecimal(OneLine.Substring(178, 6).Trim());
                        MerchantTranInfo.ResponseCode = OneLine.Substring(185, 2).Trim();
                        MerchantTranInfo.POSEntryMode = Convert.ToDecimal(OneLine.Substring(188, 3).Trim());
                        MerchantTranInfo.SvcFeeRec = Convert.ToDecimal(OneLine.Substring(192, 12).Trim());
                        MerchantTranInfo.SvcFeePayable = Convert.ToDecimal(OneLine.Substring(205, 12).Trim());
                        MerchantTranInfo.InterchangeSvcFee = Convert.ToDecimal(OneLine.Substring(218, 12).Trim());
                        MerchantTranInfo.SwitchFlag = Convert.ToDecimal(OneLine.Substring(231, 1).Trim());
                        if (STFFileName.Contains("2B"))
                            MerchantTranInfo.ReservedForUse = null;    
                        else
                        MerchantTranInfo.ReservedForUse = OneLine.Substring(233, 66).Trim();
                        MerchantTranInfo.CreatedDate = DateTime.Now;
                        MerchantTranInfo.BatchNo = DateTime.Now.Day + DateTime.Now.Month + DateTime.Now.Year;
                        MerchantTranInfo.FileName = STFFileName;
                        var test1 = Convert.ToDateTime(DateTime.Now);
                        var test =Convert.ToDateTime(STFFileName.Substring(7, 2) + "/" + STFFileName.Substring(5, 2) +  "/" + STFFileName.Substring(3, 2));
                        MerchantTranColl.Add(MerchantTranInfo);
                    }
                }
                SeqLog.TraceLog("Merchant Trail File Reading one by one finish at = > " + DateTime.Now, FileName);
            }
            catch (Exception ex)
            {
                SeqLog.TraceLog("MerchantTrailFileProcess Event Fail at = > " + DateTime.Now, FileName);
                SeqLog.TraceLog("Err Desc: = > " + ex.Message, FileName);
                SeqLog.TraceLog("================================================ " + DateTime.Now, FileName);
            }
            SeqLog.TraceLog("Merchant Trail File Data Process start at = > " + DateTime.Now, FileName);
            DMLStringExecuterController DMLCtrl = new DMLStringExecuterController();
            DataTable dml = DMLCtrl.DMLStringExecuter("DELETE FROM [MerchantDetailTransaction_Info] WHERE FILENAME = '" + STFFileName + "'");
            MerchantDetailTransaction_InfoController MerchantTranCtrl = new MerchantDetailTransaction_InfoController();
            if (!MerchantTranCtrl.Add(MerchantTranColl))
                SeqLog.TraceLog("Merchant Trail File Data Process fail at = > " + DateTime.Now, FileName);
            else
                SeqLog.TraceLog("Merchant Trail File Data Process finish at = > " + DateTime.Now, FileName);
            SeqLog.TraceLog("================================================ " + DateTime.Now, FileName);
        }

        /// <summary>
        /// Checking MPU files, logging and defining what type are they....
        /// </summary>
        /// <param name="MPUFileName"></param>
        /// <param name="_type"></param>
        /// <returns>_type as string</returns>
        private bool MPUFileChecking(string MPUFileName, out string _type)
        {
            SequenceLog SeqLog = new SequenceLog();
            _type = string.Empty;
            try
            {
                SeqLog.TraceLog("SettlementFileChecking Event Start at  = > " + DateTime.Now, FileName);
                
                switch (MPUFileName.Substring(0, 3))
                {
                    case "MCC":
                        _type = "MCS"; //Merchant Settlement File
                        SeqLog.TraceLog("SettlementFileChecking Event Finish at  = > " + DateTime.Now + Environment.NewLine + "File Type is = > " + _type, FileName);
                        return true;

                    case "MCD":
                        _type = "MCD"; //Merchant Settlement Detail Transaction File
                        SeqLog.TraceLog("SettlementFileChecking Event Finish at  = > " + DateTime.Now + Environment.NewLine + "File Type is = > " + _type, FileName);
                        return true;

                    case "IND":  //Member Bank Settlement and Detail Files
                        if (MPUFileName.Substring(11, 1) == "I" && MPUFileName.Substring(12, 3) == "COM")
                            _type = "MBICom"; // Member Bank Issuing Transaction File
                        else if (MPUFileName.Substring(11, 1) == "A" && MPUFileName.Substring(12, 3) == "COM")
                            _type = "MBACom"; // Member Bank Acquiring Transaction File
                        else if (MPUFileName.Substring(11, 1) == "A" && MPUFileName.Substring(12, 3) == "ERR")
                            _type = "MBAcomE"; // Member Bank Acquiring Transaction Err File
                        else if (MPUFileName.Substring(11, 1) == "I" && MPUFileName.Substring(12, 3) == "ERR")
                            _type = "MBIcomE"; // Member Bank Issuing Transaction Err File
                        else if (MPUFileName.Substring(11, 4) == "SCOM")
                            _type = "MBScom"; //  For Member Bank Settlement file Acom+Icom  Summary (Newly added)
                        else if (MPUFileName.Substring(11, 1) == "B" && MPUFileName.Substring(12, 3) == "COM")
                            _type = "BCOM"; // Member Bank Acquiring Transaction Err File
                        //else if()
                        SeqLog.TraceLog("SettlementFileChecking Event Finish at  = > " + DateTime.Now + Environment.NewLine + "File Type is = > " + _type, FileName);
                        return true;

                    case "INC":  //Merchant (Ecom+POS) Acq/Iss Settlement files and detail file
                        if (MPUFileName.Substring(11, 1) == "S" && MPUFileName.Substring(9, 3) == "01S")
                            _type = "MBAS"; // Member Bank Settlement File
                        else if (MPUFileName.Substring(11, 1) == "E" && MPUFileName.Substring(9, 3) == "01E")
                            _type = "MBAE"; //Member Bank Error File
                        else if (MPUFileName.Substring(11, 1) == "C" && MPUFileName.Substring(9, 3) == "01C")
                            _type = "MBAC";  //Member Bank Detail File
                        else if (MPUFileName.Substring(11, 1) == "S" && MPUFileName.Substring(9, 3) == "11S")
                            _type = "MBIS";
                        else if (MPUFileName.Substring(11, 1) == "E" && MPUFileName.Substring(9, 3) == "11E")
                            _type = "MBIE";
                        else if (MPUFileName.Substring(11, 1) == "C" && MPUFileName.Substring(9, 3) == "11C")
                            _type = "MBIC";
                        SeqLog.TraceLog("SettlementFileChecking Event Finish at  = > " + DateTime.Now + Environment.NewLine + "File Type is = > " + _type, FileName);
                        return true;

                    case "TT4":
                        if (MPUFileName.Substring(0, 5) == "TT464")
                            _type = "T464";
                        SeqLog.TraceLog("SettlementFileChecking Event Finish at  = > " + DateTime.Now + Environment.NewLine + "File Type is = > " + _type, FileName);
                        return true;
                    //break;
                    default:
                        throw new Exception("Invalid File Name File Name is = >" + MPUFileName);
                }
            }
            catch (Exception ex)
            {
                SeqLog.TraceLog("SettlementFileChecking Event Fail at  = > " + DateTime.Now, FileName);
                SeqLog.TraceLog("Err Desc = > " + ex.Message, FileName);
                _type = "";
                return false;
            }
        }

        /// <summary>
        /// Merchant Settlement Process for parsing Merchant code and insert into database.
        /// </summary>
        /// <param name="Stw" type="StreamReader"></param>
        /// <param name="STFFileName" type="string"></param>
        /// <param name="STFDate" type="DateTime"></param>
        private void MerchantSettlementProcess(StreamReader Stw, string STFFileName, out DateTime STFDate)
        {
            SequenceLog SeqLog = new SequenceLog();
            Settlement_InfoCollections STINfoColl = new Settlement_InfoCollections();
            Settlement_InfoInfo StInfo;
            STFDate = DateTime.Now;
            SeqLog.TraceLog("Merchant Settlement File Reading one by one start at = >" + DateTime.Now, FileName);

            //Reading downloaded file...
            while (!Stw.EndOfStream)
            {
                try
                {
                    StInfo = new Settlement_InfoInfo();
                    string OneLine = Stw.ReadLine();
                    if (OneLine.Trim() != string.Empty)
                    {
                        string Rescode = OneLine.Substring(0, 3).Trim();
                        if (Rescode == "000")
                        {
                            OneLine = Stw.ReadLine();
                        }
                        else if (Rescode == "901" || Rescode == "902")
                        {
                        }
                        else
                        {
                            SeqLog.TraceLog("Data = > " + OneLine, FileName);
                            StInfo.ResCode = OneLine.Substring(0, 3).Trim();
                            StInfo.MPUDfCode = OneLine.Substring(4, 11).Trim();
                            StInfo.OutgoingAmoutSign = OneLine.Substring(15, 1).Trim();
                            StInfo.OutgoingAmount = Convert.ToDecimal(OneLine.Substring(16, 14).Trim() + "." + OneLine.Substring(30, 2).Trim());
                            StInfo.OutgoingFeeSign = OneLine.Substring(47, 1).Trim();
                            StInfo.OutgoingFee = Convert.ToDecimal(OneLine.Substring(49, 14).Trim() + "." + OneLine.Substring(63, 2).Trim());
                            StInfo.IncomingAmountSign = OneLine.Substring(15, 1).Trim();
                            StInfo.IncomingAmount = Convert.ToDecimal(OneLine.Substring(16, 14).Trim() + "." + OneLine.Substring(30, 2).Trim());
                            StInfo.IncomingFeeSign = OneLine.Substring(47, 1).Trim();
                            StInfo.IncomingFee = Convert.ToDecimal(OneLine.Substring(49, 14).Trim() + "." + OneLine.Substring(63, 2).Trim());

                            StInfo.STFAmountSign = OneLine.Substring(15, 1).Trim();
                            StInfo.STFAmount = Convert.ToDecimal(OneLine.Substring(16, 14).Trim() + "." + OneLine.Substring(30, 2).Trim());
                            StInfo.STFFeeSign = OneLine.Substring(47, 1).Trim();
                            StInfo.STFFee = Convert.ToDecimal(OneLine.Substring(49, 14).Trim() + "." + OneLine.Substring(63, 2).Trim());

                            StInfo.TotalSettlementAmtSign = OneLine.Substring(66, 1).Trim();
                            StInfo.TotalSettlementAmt = Convert.ToDecimal(OneLine.Substring(68, 14).Trim() + "." + OneLine.Substring(68 + 14, 2).Trim());

                            StInfo.IncomingSummary = Convert.ToDecimal(OneLine.Substring(85, 11).Trim());
                            StInfo.SettlementCurrency = OneLine.Substring(96, 4).Trim();
                            StInfo.CreatedDate = DateTime.Now;
                            StInfo.MerchantSettlementAccount = OneLine.Substring(101, 33).Trim();
                            StInfo.Reserved = OneLine.Substring(131).Trim();
                            StInfo.FileType = "MC";
                            StInfo.SettlementFileName = STFFileName;
                            string settlementDateConverter = STFFileName.Substring(7, 2) + "/" + STFFileName.Substring(5, 2) + "/" + STFFileName.Substring(3, 2);
                            StInfo.SettlementDate = Convert.ToDateTime(settlementDateConverter);
                            clsGlobal.vSTFDate = StInfo.SettlementDate;
                            STINfoColl.Add(StInfo);
                        }
                    }
                    STFDate = StInfo.SettlementDate;
                }
                catch (Exception ex)
                {
                    SeqLog.TraceLog("Merchant Settlement File Reading one by one fail at = >" + DateTime.Now, FileName);
                    SeqLog.TraceLog("Err Description = >" + ex.Message, FileName);
                }
            }

            SeqLog.TraceLog("Merchant Settlement File Reading one by one finish at = >" + DateTime.Now, FileName);
            SeqLog.TraceLog("Merchant Settlement File Writing Start at = > " + DateTime.Now, FileName);
            Settlement_InfoController StCtrl = new Settlement_InfoController();

            //Delete STF file from database...
            StCtrl.DeleteBySTFFileName(STFFileName);

            //Insert new Merchant file into database...
            if (StCtrl.Add(STINfoColl))
                SeqLog.TraceLog("Merchant Settlement_Info data write finish for at = >" + DateTime.Now, FileName);
            else
                SeqLog.TraceLog("Merchant Settlement_Info data write fail at = >" + DateTime.Now, FileName);
        }

        private void MemberBankSettlementProcess(StreamReader Stw, string STFFileName, out DateTime STFDate)
        {
            SequenceLog SeqLog = new SequenceLog();
            Settlement_InfoController StInfoCtrl = new Settlement_InfoController();
            Settlement_InfoCollections StInfoColl = new Settlement_InfoCollections();
            Settlement_InfoInfo StInfo;
            STFDate = DateTime.Now;
            try
            {
                while (!Stw.EndOfStream)
                {
                    int startpoint = 0;
                    SeqLog.TraceLog("Member Bank SettlementProcess start at = >" + DateTime.Now, FileName);
                    string OneLine = Stw.ReadLine();
                    string RespCode = OneLine.Substring(0, 3).Trim();

                    if (OneLine.Trim() != string.Empty)
                    {
                        if (RespCode.Trim() == "000" || RespCode.Trim() == "901" || RespCode.Trim() == "902" || RespCode.Trim() == "001")
                        {
                            continue;
                        }
                        else
                        {
                            SeqLog.TraceLog("Data = > " + OneLine, FileName);
                            StInfo = new Settlement_InfoInfo();
                            StInfo.ResCode = Convert.ToString(OneLine.Substring(startpoint, 3).Trim());
                            startpoint = startpoint + 3;
                            StInfo.MPUDfCode = Convert.ToString(OneLine.Substring(startpoint, 11).Trim());
                            startpoint = startpoint + 11;
                            StInfo.OutgoingAmoutSign = Convert.ToString(OneLine.Substring(startpoint, 1).Trim());
                            startpoint = startpoint + 1;
                            StInfo.OutgoingAmount = Convert.ToDecimal(OneLine.Substring(startpoint, 14).Trim() + "." + OneLine.Substring(startpoint + 14, 2));
                            startpoint = startpoint + 16;
                            StInfo.OutgoingFeeSign = Convert.ToString(OneLine.Substring(startpoint, 1).Trim());
                            startpoint = startpoint + 1;
                            StInfo.OutgoingFee = Convert.ToDecimal(OneLine.Substring(startpoint, 14).Trim() + "." + OneLine.Substring(startpoint + 14, 2).Trim());
                            startpoint = startpoint + 16;
                            StInfo.IncomingAmountSign = Convert.ToString(OneLine.Substring(startpoint, 1).Trim());
                            startpoint = startpoint + 1;
                            StInfo.IncomingAmount = Convert.ToDecimal(OneLine.Substring(startpoint, 14).Trim() + "." + OneLine.Substring(startpoint + 14, 2).Trim());
                            startpoint = startpoint + 16;
                            StInfo.IncomingFeeSign = Convert.ToString(OneLine.Substring(startpoint, 1));
                            startpoint = startpoint + 1;
                            StInfo.IncomingFee = Convert.ToDecimal(OneLine.Substring(startpoint, 14).Trim() + "." + OneLine.Substring(startpoint + 14, 2).Trim());
                            startpoint = startpoint + 16;
                            StInfo.STFAmountSign = Convert.ToString(OneLine.Substring(startpoint, 1).Trim());
                            startpoint = startpoint + 1;
                            StInfo.STFAmount = Convert.ToDecimal(OneLine.Substring(startpoint, 14).Trim() + "." + OneLine.Substring(startpoint + 14, 2).Trim());
                            startpoint = startpoint + 16;
                            StInfo.STFFeeSign = Convert.ToString(OneLine.Substring(startpoint, 1).Trim());
                            startpoint = startpoint + 1;
                            StInfo.STFFee = Convert.ToDecimal(OneLine.Substring(startpoint, 14).Trim() + "." + OneLine.Substring(startpoint + 14, 2).Trim());
                            startpoint = startpoint + 16;
                            StInfo.OutgoingSummary = Convert.ToDecimal(OneLine.Substring(startpoint, 10));
                            startpoint = startpoint + 10;
                            StInfo.IncomingSummary = Convert.ToDecimal(OneLine.Substring(startpoint, 10));
                            startpoint = startpoint + 10;
                            StInfo.SettlementCurrency = Convert.ToString(OneLine.Substring(startpoint, 3));
                            startpoint = startpoint + 3;
                            StInfo.Reserved = Convert.ToString(OneLine.Substring(startpoint, 30).Trim());
                            StInfo.FileType = "MB";
                            StInfo.CreatedDate = DateTime.Now;
                            StInfo.SettlementFileName = STFFileName;

                            // StInfo.SettlementDate = Convert.ToDateTime(STFFileName.Substring(7, 2) + "/" + STFFileName.Substring(5, 2) + "/" + STFFileName.Substring(3, 2));

                           StInfo.SettlementDate = Convert.ToDateTime(STFFileName.Substring(7, 2) + "/" + STFFileName.Substring(5, 2) + "/" + DateTime.Now.Year.ToString(), 
                                   System.Globalization.CultureInfo.GetCultureInfo("hi-IN").DateTimeFormat);


                            clsGlobal.vSTFDate = StInfo.SettlementDate;
                            STFDate = StInfo.SettlementDate;
                            StInfoColl.Add(StInfo);
                        }
                    } //stw.EndofStream
                }
                StInfoCtrl.DeleteBySTFFileName(STFFileName);
                if (!StInfoCtrl.Add(StInfoColl))
                    throw new Exception("Settlement Process Fail at database.");
                else
                    SeqLog.TraceLog("Member Bank SettlementProcess Finish at = >" + DateTime.Now, FileName);
            }
            catch (Exception ex)
            {
                SeqLog.TraceLog("Member Bank SettlementProcess Fail at = >" + DateTime.Now, FileName);
                SeqLog.TraceLog("Err Description = >" + ex.Message, FileName);
            }
        }

        /// <summary>
        /// MerchantTransactionDetailFileFormatLengthReader
        /// </summary>
        /// <param name="MerchantSTDetailLength"></param>
        /// <returns></returns>
        private bool MerchantTransactionDetailFileFormatLengthReader(out DataTable MerchantSTDetailLength)
        {
            MerchantSTDetailLength = new DataTable();
            SequenceLog Seqlog = new SequenceLog();
            try
            {
                Seqlog.TraceLog("<< ================================================== >>", FileName);
                Seqlog.TraceLog("MerchantTransactionDetailFileFormatLengthReader Event Start at   == >> " + DateTime.Now, FileName);
                StreamReader MerchantList = new StreamReader(Application.StartupPath + @"\SettlementFileProcess.xml");
                MerchantSTDetailLength.ReadXml(MerchantList);
                if (MerchantSTDetailLength.Rows.Count <= 0)
                    throw new Exception("There is no row at file.");
                Seqlog.TraceLog("MerchantTransactionDetailFileFormatLengthReader Event Finish at   == >> " + DateTime.Now, FileName);
                Seqlog.TraceLog("<< ================================================== >>", FileName);
                return true;
            }
            catch (Exception ex)
            {
                Seqlog.TraceLog("MerchantTransactionDetailFileFormatLengthReader Event Fail at  = >>" + DateTime.Now, FileName);
                Seqlog.TraceLog("Err Desc  = >>" + ex.Message, FileName);
                Seqlog.TraceLog("<< ================================================== >>", FileName);
                return false;
            }
        }

        #endregion Customize Events...

        /// <summary>
        /// Start Downloading...
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnstart_Click(object sender, EventArgs e)
        {
            int i = 0;
            try
            {
                btnstart.Enabled = false;
                ResourceReader Rsr = new ResourceReader(Application.StartupPath + @"\STFCongif");
                IDictionaryEnumerator IDE = Rsr.GetEnumerator();
                IDE.Reset();
                while (IDE.MoveNext())
                {
                    if (Convert.ToString(IDE.Key) == "Schedule")
                        downloadtime = Convert.ToString(IDE.Value);
                    else if (Convert.ToString(IDE.Key) == "Type")
                        type = Convert.ToString(IDE.Value);
                }
                Rsr.Close();
                DownloadThd = new Thread(new ThreadStart(DownloadScheduleWaiting));
                DownloadThd.Start();
                this.WindowState = FormWindowState.Minimized;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                i++;
            }
            finally
            {
                if (i != 0)
                    MessageBox.Show("Download Process completed but some errors occured!" + Environment.NewLine + "Please check in the log files...", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                    MessageBox.Show("Download Process completed without errors!", "Download Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        /// <summary>
        /// Abort Downloading...
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnend_Click(object sender, EventArgs e)
        {
            try
            {
                btnstart.Enabled = true;
                DownloadThd.Abort();
            }
            catch (Exception) { }
        }
    }
}