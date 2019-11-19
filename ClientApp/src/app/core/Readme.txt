The CoreModule of the application is responsible for keeping global services.

Most likely, these services will be HTTP services to communicate with a back-end API.

I also use the core module to store guards, models and other global dependencies such as http interceptor and global error handler.

Please note that there should only ever be a single core module.

This is so that the services registered in the core module are only instantiated once in the lifetime of the app.

You can conveniently force the single-use of the core module.
