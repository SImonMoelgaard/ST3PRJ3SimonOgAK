﻿using System;
using System.Collections.Generic;
using DTO;

namespace DataAccessLogic
{
    public interface IDatabase
    {
        public List<DTO_Measurement> GetMeasurement(string socSecNB);
        public void SaveMeasurement(string socSecNb, double rawData, DateTime date, int sysData, int diaData,
            int alarmData, int pulse, int powerData);

        public bool isUserRegistered(String socSecNb, String pw);
        public bool getSocSecNB(string SocSecNB);

        public void SavePatientData(int sysHigh, int sysLow, int diaHigh, int diaLow, string cprPatient);


    }
}