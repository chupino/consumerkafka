using System;
using Confluent.Kafka;

namespace KafkaConsumerExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Configuración del consumidor
            var config = new ConsumerConfig
            {
                BootstrapServers = "18.208.213.203:9093",
                GroupId = "test-consumer-group",
                AutoOffsetReset = AutoOffsetReset.Earliest
            };

            // Crear el consumidor
            using (var consumer = new ConsumerBuilder<Ignore, string>(config).Build())
            {
                consumer.Subscribe("testtopic");

                Console.WriteLine("Esperando mensajes...");

                // Leer mensajes
                try
                {
                    while (true)
                    {
                        var cr = consumer.Consume();
                        Console.WriteLine($"Mensaje recibido: {cr.Value}");
                    }
                }
                catch (ConsumeException e)
                {
                    Console.WriteLine($"Error al consumir mensaje: {e.Error.Reason}");
                }
                finally
                {
                    consumer.Close();
                }
            }
        }
    }
}
