//
// RetroKS  Copyright (C) 2022  Aptivi
//
// This file is part of RetroKS
//
// RetroKS is free software: you can redistribute it and/or modify
// it under the terms of the GNU General Public License as published by
// the Free Software Foundation, either version 3 of the License, or
// (at your option) any later version.
//
// RetroKS is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY, without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU General Public License for more details.
//
// You should have received a copy of the GNU General Public License
// along with this program.  If not, see <https://www.gnu.org/licenses/>.
//

using System;
using System.ComponentModel;
using System.Threading;

namespace RetroKS
{

    static class TimeDate
    {

        // Variables
        public static string strKernelTimeDate;
        public static DateTime KernelDateTime = new DateTime();
        public static BackgroundWorker TimeDateChange;

        static TimeDate()
        {
            TimeDateChange = new BackgroundWorker();
        }

        public static void TimeDateChange_DoWork(object sender, DoWorkEventArgs e)
        {

            while (true)
            {

                if (TimeDateChange.CancellationPending == true)
                {
                    e.Cancel = true;
                    break;
                }
                else
                {
                    KernelDateTime = DateTime.Now;
                    strKernelTimeDate = DateTime.Now.ToString();
                }
                Thread.Sleep(500);

            }

        }

        public static void InitializeTimeDate()
        {

            KernelDateTime = DateTime.Now;
            strKernelTimeDate = DateTime.Now.ToString();
            TimeDateChange.WorkerSupportsCancellation = true;
            TimeDateChange.RunWorkerAsync();
            ShowTimeQuiet();

        }

        public static void ShowTime()
        {

            TextWriterColor.Wln("datetime: Time is {0}", Convert.ToDateTime(strKernelTimeDate).ToLongTimeString());
            TextWriterColor.Wln("datetime: Today is {0}", Convert.ToDateTime(strKernelTimeDate).ToLongDateString());

        }

        public static void ShowTimeQuiet()
        {

            if (Flags.Quiet == false)
            {
                ShowTime();
            }

        }

    }
}