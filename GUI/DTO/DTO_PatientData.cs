﻿using System;
using System.Collections.Generic;
using System.Text;

namespace DTO
{
    public class DTO_PatientData
    {
        ///// <summary>
        ///// Limit value - low systolic
        ///// </summary>
        //public int SysLow { get; set; }

        ///// <summary>
        ///// Limit value - high systolic
        ///// </summary>
        //public int SysHigh { get; set; }

        ///// <summary>
        ///// Limit value - low diastolic
        ///// </summary>
        //public int DiaLow { get; set; }

        ///// <summary>
        ///// Limit value - high diastolic
        ///// </summary>
        //public int DiaHigh { get; set; }

        ///// <summary>
        ///// Limit value - low mean
        ///// </summary>
        //public int LowMean { get; set; }

        ///// <summary>
        ///// Limit value - high mean
        ///// </summary>
        //public int HighMean { get; set; }

        ///// <summary>
        ///// CPR
        ///// </summary>
        //public string SocSecNB { get; set; }

        ///// <summary>
        ///// Calibration value
        ///// </summary>
        //public double CalVal { get; set; }

        ///// <summary>
        ///// Zero value
        ///// </summary>
        //public double ZeroVal { get; set; }

        public int HighSys
        {
            get;
            set;
        }

        public int LowSys
        {
            get;
            set;
        }

        public int HighDia
        {
            get;
            set;
        }

        public int LowDia
        {
            get;
            set;
        }
        public int HighMean
        {
            get;
            set;
        }

        public int LowMean
        {
            get;
            set;
        }
        public double ZeroVal
        {
            get;
            set;
        }
        public string SocSecNB { get; set; }
        public double CalVal { get; set; }
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="sysLow"></param>
        /// <param name="sysHigh"></param>
        /// <param name="diaLow"></param>
        /// <param name="diaHigh"></param>
        /// <param name="lowMean"></param>
        /// <param name="highMean"></param>
        /// <param name="socSecNB"></param>
        /// <param name="calVal"></param>
        /// <param name="zeroVal"></param>
        public DTO_PatientData(int sysLow, int sysHigh, int diaLow, int diaHigh, int lowMean, int highMean, string socSecNB, double calVal, double zeroVal)
        {
            HighSys = sysHigh;
            LowSys = sysLow;
            HighDia = diaHigh;
            LowDia = diaLow;
            HighMean = highMean;
            LowMean = lowMean;
            ZeroVal = zeroVal;
            CalVal = calVal;
            SocSecNB = socSecNB;



            //SysLow = sysLow;
            //SysHigh = sysHigh;
            //DiaLow = diaLow;
            //DiaHigh = diaHigh;
            //LowMean = lowMean;
            //HighMean = highMean;
            //SocSecNB = socSecNB;
            //CalVal = calVal;
            //ZeroVal = zeroVal;

        }
    }
}
