# SSMLBuilder.Azure
SSMLBuilder.Azure is a .NET library designed to simplify the creation of Speech Synthesis Markup Language (SSML) for use with Azure's Cognitive Speech Services. It provides a fluent interface to construct SSML documents, making it easier to generate speech synthesis requests with various voice and language configurations.

## Using This Library
For real-world examples of how to use this library, check out our [test suite](https://github.com/L3mur1/SSMLBuilder.Azure/tree/master/src/Tests/SSMLBuilderAzure.UnitTests/Elements).

The root element of an SSML document is the `Speak` element. You can create a new `Speak` element like this:

[speak element](https://github.com/L3mur1/SSMLBuilder.Azure/blob/master/src/Tests/SSMLBuilderAzure.UnitTests/Elements/SpeakTests.cs)

you can view the ouput of the above code - SSML output in Verify files directory, example for Speak with multiple elements:

[speak element output](https://github.com/L3mur1/SSMLBuilder.Azure/blob/master/src/Tests/SSMLBuilderAzure.UnitTests/verify_files/SpeakTests.WhenMultipleElements.verified.txt)
