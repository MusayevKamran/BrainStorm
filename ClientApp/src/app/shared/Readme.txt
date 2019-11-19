SharedModule contains code that will be used across your feature modules.

You only import the SharedModule into the specific feature modules.

Ensure you don’t import the SharedModule into your AppModule or CoreModule.

Application-wide singleton services do not belong to the SharedModule, they should be in the CoreModule.

SharedModule is only for keeping common components, pipes & directives.

Layout component is a great example of a shared component
