using System;
using System.Collections.Generic;
using System.Text;

namespace Tunnel.Model
{
    public class Tunnel_ReadCheckList
    {
        private int userId = 0;

        public int UserId
        {
            get { return userId; }
            set { userId = value; }
        }
        private string userName = string.Empty;

        public string UserName
        {
            get { return userName; }
            set { userName = value; }
        }
        private string itemsName = string.Empty;

        public string ItemsName
        {
            get { return itemsName; }
            set { itemsName = value; }
        }
        private int itemsID = 0;

        public int ItemsID
        {
            get { return itemsID; }
            set { itemsID = value; }
        }
        private string cbkzName = string.Empty;

        public string CbkzName
        {
            get { return cbkzName; }
            set { cbkzName = value; }
        }
        private float cbkzCent = 0;

        public float CbkzCent
        {
            get { return cbkzCent; }
            set { cbkzCent = value; }
        }
        private string cbkzBumName = string.Empty;

        public string CbkzBumName
        {
            get { return cbkzBumName; }
            set { cbkzBumName = value; }
        }
        private string xnzhName = string.Empty;

        public string XnzhName
        {
            get { return xnzhName; }
            set { xnzhName = value; }
        }
        private float xnzhCent = 0;

        public float XnzhCent
        {
            get { return xnzhCent; }
            set { xnzhCent = value; }
        }
        private string xnzhBumName = string.Empty;

        public string XnzhBumName
        {
            get { return xnzhBumName; }
            set { xnzhBumName = value; }
        }
        private string scjhName = string.Empty;

        public string ScjhName
        {
            get { return scjhName; }
            set { scjhName = value; }
        }
        private float scjhCent = 0;

        public float ScjhCent
        {
            get { return scjhCent; }
            set { scjhCent = value; }
        }
        private string scjhBumName = string.Empty;

        public string ScjhBumName
        {
            get { return scjhBumName; }
            set { scjhBumName = value; }
        }
        private string wmsgName = string.Empty;

        public string WmsgName
        {
            get { return wmsgName; }
            set { wmsgName = value; }
        }
        private float wmsgCent = 0;

        public float WmsgCent
        {
            get { return wmsgCent; }
            set { wmsgCent = value; }
        }
        private string wmsgBumName = string.Empty;

        public string WmsgBumName
        {
            get { return wmsgBumName; }
            set { wmsgBumName = value; }
        }
        private string aqscName = string.Empty;

        public string AqscName
        {
            get { return aqscName; }
            set { aqscName = value; }
        }
        private float aqscCent = 0;

        public float AqscCent
        {
            get { return aqscCent; }
            set { aqscCent = value; }
        }
        private string aqscBumName = string.Empty;

        public string AqscBumName
        {
            get { return aqscBumName; }
            set { aqscBumName = value; }
        }
        private string gczlName = string.Empty;

        public string GczlName
        {
            get { return gczlName; }
            set { gczlName = value; }
        }
        private float gczlCent = 0;

        public float GczlCent
        {
            get { return gczlCent; }
            set { gczlCent = value; }
        }
        private string gczlBumName = string.Empty;

        public string GczlBumName
        {
            get { return gczlBumName; }
            set { gczlBumName = value; }
        }
        private string sbglName = string.Empty;

        public string SbglName
        {
            get { return sbglName; }
            set { sbglName = value; }
        }
        private float sbglCent = 0;

        public float SbglCent
        {
            get { return sbglCent; }
            set { sbglCent = value; }
        }
        private string sbglBumName = string.Empty;

        public string SbglBumName
        {
            get { return sbglBumName; }
            set { sbglBumName = value; }
        }
        private string clglName = string.Empty;

        public string ClglName
        {
            get { return clglName; }
            set { clglName = value; }
        }
        private float clglCent = 0;

        public float ClglCent
        {
            get { return clglCent; }
            set { clglCent = value; }
        }
        private string clglBumName = string.Empty;

        public string ClglBumName
        {
            get { return clglBumName; }
            set { clglBumName = value; }
        }
        private string zhzlName = string.Empty;

        public string ZhzlName
        {
            get { return zhzlName; }
            set { zhzlName = value; }
        }
        private float zhzlCent = 0;

        public float ZhzlCent
        {
            get { return zhzlCent; }
            set { zhzlCent = value; }
        }
        private string zhzlBumName = string.Empty;

        public string ZhzlBumName
        {
            get { return zhzlBumName; }
            set { zhzlBumName = value; }
        }
        private string gbgzName = string.Empty;

        public string GbgzName
        {
            get { return gbgzName; }
            set { gbgzName = value; }
        }
        private float gbgzCent = 0;

        public float GbgzCent
        {
            get { return gbgzCent; }
            set { gbgzCent = value; }
        }
        private string gbgzBumName = string.Empty;

        public string GbgzBumName
        {
            get { return gbgzBumName; }
            set { gbgzBumName = value; }
        }
        private string xcgzName = string.Empty;

        public string XcgzName
        {
            get { return xcgzName; }
            set { xcgzName = value; }
        }
        private float xcgzCent = 0;

        public float XcgzCent
        {
            get { return xcgzCent; }
            set { xcgzCent = value; }
        }
        private string xcgzBumName = string.Empty;

        public string XcgzBumName
        {
            get { return xcgzBumName; }
            set { xcgzBumName = value; }
        }
        private string dzbgzName = string.Empty;

        public string DzbgzName
        {
            get { return dzbgzName; }
            set { dzbgzName = value; }
        }
        private float dzbgzCent = 0;

        public float DzbgzCent
        {
            get { return dzbgzCent; }
            set { dzbgzCent = value; }
        }
        private string dzbgzBumName = string.Empty;

        public string DzbgzBumName
        {
            get { return dzbgzBumName; }
            set { dzbgzBumName = value; }
        }
        private string xxgzName = string.Empty;

        public string XxgzName
        {
            get { return xxgzName; }
            set { xxgzName = value; }
        }
        private float xxgzCent = 0;

        public float XxgzCent
        {
            get { return xxgzCent; }
            set { xxgzCent = value; }
        }
        private string xxgzBumName = string.Empty;

        public string XxgzBumName
        {
            get { return xxgzBumName; }
            set { xxgzBumName = value; }
        }
        private float allCent = 0;

        public float AllCent
        {
            get { return allCent; }
            set { allCent = value; }
        }
        private string income = string.Empty;

        public string Income
        {
            get { return income; }
            set { income = value; }
        }

    }
}

