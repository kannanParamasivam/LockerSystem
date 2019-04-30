using System;

public static class Util {

    public static string CreateUniqueID()
    {
        return Guid.NewGuid().ToString();
    }

}