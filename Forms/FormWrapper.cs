﻿using System.Collections.Generic;

namespace Leayal.Forms
{
    public static class FormWrapper
    {
        public static IEnumerable<System.Windows.Forms.Control> GetControls(System.Windows.Forms.Form _container)
        {
            List<System.Windows.Forms.Control> cl = new List<System.Windows.Forms.Control>();
            if (_container.HasChildren)
                foreach (System.Windows.Forms.Control c in _container.Controls)
                    cl.AddRange(ControlWrapper.GetControls(c));
            return cl;
        }

        public static IEnumerable<object> GetAllControls(System.Windows.Forms.Form _container)
        {
            List<object> cl = new List<object>();
            if (_container.HasChildren)
                foreach (System.Windows.Forms.Control c in _container.Controls)
                    cl.AddRange(ControlWrapper.GetAllControls(c));
            return cl;
        }

        public static IEnumerable<FakeControl> GetFakeControls(System.Windows.Forms.Form _container)
        {
            List<FakeControl> cl = new List<FakeControl>();
            IFakeControlContainer fccontainer = _container as IFakeControlContainer;
            if (fccontainer != null)
            {
                foreach (FakeControl c in fccontainer.Controls)
                    cl.AddRange(ControlWrapper.GetFakeControls(c));
            }
            else
            {
                if (_container.HasChildren)
                    foreach (System.Windows.Forms.Control c in _container.Controls)
                        cl.AddRange(ControlWrapper.GetFakeControls(c));
            }
            return cl;
        }

        internal static float _ScalingFactor = -1f;
        public static float ScalingFactor { get
            {
                if (_ScalingFactor < 0)
                    return SystemEvents.InnerSystemEvents.GetResolutionScale();
                return _ScalingFactor;
            }
        }
    }
}
