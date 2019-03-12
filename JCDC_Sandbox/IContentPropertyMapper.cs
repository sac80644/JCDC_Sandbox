using System.Collections.Generic;

namespace JCDC_Sandbox
{
    public interface IContentPropertyMapper
    {
        /// <summary>
        /// Takes a string of a certain format, parses and maps the property values to their property names (key, value)
        /// </summary>
        /// <param name="properties"></param>
        /// <returns></returns>
        Dictionary<string, string> MapProperties(string properties);
        Dictionary<string, string>[] MapProperties(string[] properties);
    }
}