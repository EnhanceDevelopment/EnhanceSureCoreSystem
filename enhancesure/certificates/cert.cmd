# Create a CA key and cert (root CA)
openssl genrsa -out enhancesure_root_ca.key 2048
openssl req -x509 -new -nodes -key enhancesure_root_ca.key -sha256 -days 1024 -out enhancesure_root_ca.crt -subj "//CN=enhancesurerootca"

# Create a key for your server
openssl genrsa -out https_enhancesure_cert.key 2048

# Create a CSR
openssl req -new -key https_enhancesure_cert.key -out https_enhancesure_cert.csr -subj "//CN=localhost"

# Sign the CSR with your root CA
openssl x509 -req -in https_enhancesure_cert.csr -CA enhancesure_root_ca.crt -CAkey enhancesure_root_ca.key -CAcreateserial -out https_enhancesure_cert.crt -days 1000 -sha256
