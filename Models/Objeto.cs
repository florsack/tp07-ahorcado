using Newtonsoft.Json;
public static class objeto{

    public static string ObjectToString<T>(T? obj)
    {
        return JsonConvert.SerializeObject(obj);
    }

    public static T? StringToObject<T>(string txt)
    {
        if (string.IsNullOrEmpty(txt))
            return default;
        else
            return JsonConvert.DeserializeObject<T>(txt);
    }

    public static string ListToString<T>( List<T> lista) {
    return JsonConvert.SerializeObject(lista);    
    }
    public static  List<T>? StringToList<T>(string Json) {
    if (string.IsNullOrEmpty(Json))
        return default;
    else 
        return JsonConvert.DeserializeObject<List<T>>(Json);
    
    }

    }
