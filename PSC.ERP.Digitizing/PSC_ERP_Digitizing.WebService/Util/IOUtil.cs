using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.AccessControl;
using System.Security.Principal;
using System.Web;

namespace PSC_ERP_Digitizing.WebService.Util
{
    public static class IOUtil
    {
        public static Boolean TrySetAllowFullAccessFileForEveryone(String filePath)
        {
            try
            {
                SetAllowFullAccessFileForEveryone(filePath);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public static void SetAllowFullAccessFileForEveryone(String filePath)
        {
            // Read the current ACL details for the file
            var fileSecurity = File.GetAccessControl(filePath);

            // Create a new rule set, based on "Everyone"
            var fileAccessRule = new FileSystemAccessRule(new NTAccount("", "Everyone"),
                  FileSystemRights.FullControl,
                  AccessControlType.Allow);

            // Append the new rule set to the file
            fileSecurity.AddAccessRule(fileAccessRule);

            // And persist it to the filesystem
            File.SetAccessControl(filePath, fileSecurity);
        }

        public static void SetAllowFullAccessDirectoryForEveryone(String dirPath)
        {
            // Read the current ACL details for the dir
            var dirSecurity = Directory.GetAccessControl(dirPath);

            // Create a new rule set, based on "Everyone"
            var fileAccessRule = new FileSystemAccessRule(new NTAccount("", "Everyone"),
                  FileSystemRights.FullControl,
                  AccessControlType.Allow);

            // Append the new rule set to the file
            dirSecurity.AddAccessRule(fileAccessRule);

            // And persist it to the filesystem
            Directory.SetAccessControl(dirPath, dirSecurity);


        }



        public static bool TryDeleteFile(string filePath)
        {
            if (File.Exists(filePath))
            {
                try
                {
                    // A.
                    // Try to delete the file.
                    File.Delete(filePath);
                    return true;
                }
                catch (IOException ex)
                {
                    // B.
                    // We could not delete the file.
                    return false;
                }
            }
            else
            {
                return true;
            }
        }
        public static bool TryDeleteDir(string dirPath)
        {
            if (Directory.Exists(dirPath))
            {
                try
                {
                    // A.
                    // Try to delete
                    Directory.Delete(dirPath);
                    return true;
                }
                catch (IOException ex)
                {
                    // B.
                    // We could not delete.
                    return false;
                }
            }
            else
            {
                return true;
            }
        }


        public static bool TryMoveFile(string filePath, String destFilePath)
        {
            if (File.Exists(filePath))
            {
                try
                {
                    if (!File.Exists(destFilePath))
                    {
                        File.Move(filePath, destFilePath);
                    }
                    else
                    {
                        File.Replace(filePath, destFilePath, destFilePath + DateTime.Now.ToString("._dd_MM_yyyy hh_mm_ss_ff") + ".backup");
                    }

                    return true;
                }
                catch (IOException ex)
                {

                    return false;
                }
            }
            else
            {
                return true;
            }
        }

        public static bool TryMoveDir(string dirPath, String destDirPath)
        {
            if (Directory.Exists(dirPath))
            {
                try
                {
                    Directory.Move(dirPath, destDirPath);
                    return true;
                }
                catch (IOException ex)
                {

                    return false;
                }
            }
            else
            {
                return true;
            }
        }
    }
}