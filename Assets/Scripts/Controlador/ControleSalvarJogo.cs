using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public static class ControleSalvarJogo
{
    public static void SalvarConfig(ConfiguracaoBean config)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "config.save";
        FileStream stream = new FileStream(path, FileMode.Create);
        ConfiguracaoBean data = new ConfiguracaoBean(config);
        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static ConfiguracaoBean CarregarConfig()
    {
        ConfiguracaoBean config = new ConfiguracaoBean();
        return config;
    }
}
