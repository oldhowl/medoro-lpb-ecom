###### .NET Core LPB Bank Medoro ECOM implementation.

For test just run "Medoro.Example" project and open app host in browser on root path.

Don't forget generate RSA key pair using OpenSSL for production mode 

``openssl genrsa -out merchant_private_key.pem 2048``

``openssl rsa -in merchant_private_key.pem -pubout -out merchant_public_key.pem``
