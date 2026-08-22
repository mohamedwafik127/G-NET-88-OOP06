using System;
using System.Collections.Generic;
using System.Text;

   public partial class Shipment : ITrackable
    {

        public string TrackingStatus { get; set; }

        public virtual string GetTrackingStatus()
        {
            return TrackingStatus;
        }

        public void UpdateTrackingStatus(string newStatus)
        {
            TrackingStatus = newStatus;
            OnTrackingStatusChanged(newStatus);
        }

        public partial void OnTrackingStatusChanged(string newStatus);

}
