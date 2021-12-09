# ChirpStack API

![Tests](https://github.com/brocaar/chirpstack-api/actions/workflows/main.yml/badge.svg?branch=master)

This repository contains the [Protobuf](https://developers.google.com/protocol-buffers/)
and [gRPC](https://grpc.io/) API definitions for the [ChirpStack](https://www.chirpstack.io)
components.

## Protobuf / gRPC structure

```
protobuf             - Protobuf and gRPC source files
├── as
│   ├── external
│   │   └── api      - Application Server External API definitions
│   └── integration  - Application Server integration definitions
├── common           - Definitions shared across ChirpStack components
├── geo              - Geolocation Server API definitions
├── gw               - LoRa gateway definitions
├── nc               - Network Controller definitions
└── ns               - Network Server definitions
```

## C\# bindings
This repository contains scripts and configuration files to generate a .Net bindings for the 
gRPC client API for the Chirpstack application server. For other languages support see:
    https://github.com/brocaar/chirpstack-api

# Install
```
    git clone https://github.com/nodriver-ai/ChirpStack.Api.git
    cd ChirpStack.Api
    ./build.sh
```
