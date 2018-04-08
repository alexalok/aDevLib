using System;
using aDevLibStandard.Extensions.CollectionsExtensions;

namespace aDevLibStandard
{
    public class Setting
    {
        public readonly string Name;
        readonly string _value;

        public Setting(string setting)
        {
            var settingSplit = setting.Split('=');
            Name = settingSplit[0].ToLower();
            settingSplit.TryGetElement(1, out _value);
        }

        public string StringValue => _value;

        public bool BoolValue
        {
            get
            {
                switch (_value.ToLower())
                {
                    case "0":
                    case "false":
                        return false;
                    case "1":
                    case "true":
                        return true;
                    default:
                        throw new InvalidCastException();
                }
            }
        }

        public bool? TryGetBoolValue
        {
            get
            {
                switch (_value.ToLower())
                {
                    case "0":
                    case "false":
                        return false;
                    case "1":
                    case "true":
                        return true;
                    default:
                        return null;
                }
            }
        }

        public int IntValue => Convert.ToInt32(_value);
    }
}