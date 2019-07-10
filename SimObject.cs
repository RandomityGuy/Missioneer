using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Missioneer
{
    public class SimObject
    {
        public string classname = "SimObject";
        public string objname = "";
        public Dictionary<string, string> dynamicFields = new Dictionary<string, string>();
        public SimGroup Collection { get; internal set; }

        public virtual string Write()
         {
            return "NULL";
         }

        public string this[string field]
        {
            get
            {
                var fields = this.GetType().GetFields();
                if (fields.Select(a => a.Name).Contains(field))
                {
                    return this.GetType().GetField(field).GetValue(this).ToString();
                }
                else
                {
                    if (dynamicFields.ContainsKey(field)) return dynamicFields[field];
                    else return "";
                }
            }

            set
            {
                var fields = this.GetType().GetFields();
                if (fields.Select(a => a.Name.ToLower()).Contains(field.ToLower()))
                {
                    var thisfield = this.GetType().GetFields().First(a => a.Name.ToLower() == field.ToLower());
                    if (thisfield.FieldType == typeof(Boolean))
                    {
                        if (value == "0") value = bool.FalseString;
                        if (value == "1") value = bool.TrueString;
                    }
                    else
                    if (thisfield.FieldType == typeof(Vector))
                    {
                        var val = new Vector(value);
                        thisfield.SetValue(this, val);
                    }
                    else
                    if (thisfield.FieldType == typeof(AngAxis))
                    {
                        var val = new AngAxis(value);
                        thisfield.SetValue(this, val);
                    }
                    else
                    thisfield.SetValue(this, Convert.ChangeType(value, thisfield.FieldType));
                }
                else
                {
                    if (dynamicFields.ContainsKey(field)) dynamicFields[field] = value;
                    else dynamicFields.Add(field, value);
                }
            }
        }
       
    }
}
