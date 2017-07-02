# RestSharp.Serializers.Newtonsoft.Json

This is a glue library that makes [Newtonsoft.JSON](https://github.com/JamesNK/Newtonsoft.Json) the default serializer for [RestSharp](https://github.com/restsharp/RestSharp). 

RestSharp removed Newtonsoft.JSON as a dependency in [version 103.0](https://github.com/restsharp/RestSharp/blob/master/releasenotes.markdown#1030---remove-dependency-on-jsonnet) which is great if you don't need all the extra capability Newtonsoft.JSON provides.

After working on several projects and getting annoyed with the limited functionality available in the default JsonSerializer include with .NET, I decided to create this project so I wouldn't have to leave a JSON serialization implementation laying around in my projects. Hopefully it helps someone else too.

## Getting Started

### Installation

This package is available as a [**nuget package**](https://www.nuget.org/packages/RestSharp.Newtonsoft.Json) on nuget.org.

### Code

This library makes a `NewtonsoftJsonSerializer` available which you can readily plug into your RestSharp request object like this:

```csharp
var request = new RestRequest();
request.JsonSerializer = new NewtonsoftJsonSerializer();
```

If you don't want to keep initializing every `RestRequest`, you can also use the **`RestSharp.Serializers.Newtonsoft.Json.RestRequest`** class instead of the one from RestSharp. They are named the same but this class will default to using the Newtonsoft.JSON serialization engine.

