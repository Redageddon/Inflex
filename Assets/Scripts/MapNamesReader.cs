using System;
using System.Collections.Generic;
using System.IO;

public static class MapNamesReader
{
    public static IEnumerable<string> GetMapNames()
    {
        return Directory.GetDirectories(Environment.ExpandEnvironmentVariables(@"%AppData%\Inflex\Maps\"));
    }
}