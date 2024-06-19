using System.Reflection;
using System.Text;

namespace EXAMPLE_API.Entities.Config
{
    public class Languages
    {
        public static string es = File.ReadAllText(Path.Combine(Environment.CurrentDirectory, "es.json"), Encoding.Default);
        public static string en = File.ReadAllText(Path.Combine(Environment.CurrentDirectory, "en.json"), Encoding.Default);

        public object this[string propertyName]
        {
            get
            {
                // probably faster without reflection:
                // like:  return Properties.Settings.Default.PropertyValues[propertyName] 
                // instead of the following
                Type myType = typeof(Languages);
                PropertyInfo myPropInfo = myType.GetProperty(propertyName);
                if (myPropInfo == null)
                {
                    return "";
                }
                return myPropInfo.GetValue(this, null);
            }
            set
            {
                Type myType = typeof(Languages);
                PropertyInfo myPropInfo = myType.GetProperty(propertyName);
                myPropInfo.SetValue(this, value, null);
            }
        }

        public string BD_SUCCESS_ERROR { get; set; } = "";
        public string BD_SUCCESS_GET { get; set; } = "";
        public string BD_SUCCESS_CREATE { get; set; } = "";
        public string BD_SUCCESS_UPDATE { get; set; } = "";
        public string BD_SUCCESS_DELETE { get; set; } = "";
        public string BD_SUCCESS_DISABLE { get; set; } = "";
        public string BD_WARNING_INVALID_OPERATION { get; set; } = "";
        public string BD_WARNING_EMPTY_PARAMETERS { get; set; } = "";
        public string BD_WARNING_EMPTY_PRINCIPAL_PARAMETERS { get; set; } = "";
        public string BD_ROLES_INVALID_ID { get; set; } = "";
        public string BD_USERS_INVALID_ID { get; set; } = "";
    }
}
