using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml;
using System.Xml.Serialization;

namespace HauntedHouseSoftware.SecureNotePad.DomainObjects
{
    public sealed class SettingsWriter
    {
        private SettingsWriter()
        {
        }
        
        public static string AssemblyDirectory
        {
            get
            { 
                return AppDomain.CurrentDomain.BaseDirectory;
            }
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1031:DoNotCatchGeneralExceptionTypes")]
        public static void WriteSettingsFile(ApplicationSettings settings)
        {
            if (settings == null)
            {
                return;
            }

            try
            {
                string path = Path.GetFullPath(AssemblyDirectory + "settings.xml");

                var serializer = new XmlSerializer(settings.GetType());
                using (var writer = XmlWriter.Create(path))
                {
                    serializer.Serialize(writer, settings);
                }
            }
            catch
            {
                // If this fails for any reason we don't want a crash, just bow out quetly.
                return;
            }
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1031:DoNotCatchGeneralExceptionTypes")]
        public static ApplicationSettings ReadSettingsFile()
        {
            try
            {                
                string path = Path.GetFullPath(AssemblyDirectory + "settings.xml");

                if (File.Exists(path))
                {
                    var serializer = new XmlSerializer(typeof(ApplicationSettings));
                    using (var reader = XmlReader.Create(path))
                    {
                        var settings = (ApplicationSettings)serializer.Deserialize(reader);
                        return settings;
                    }
                }

                return null;
            }
            catch
            {
                // If this fails for any reason we don't want a crash, just bow out quetly.
                return null;
            }
        }
    }
}
