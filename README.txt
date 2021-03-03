=== Ethereum Searcher ===

Given a block and an ethereum address, this API will search the ethereum blockchain for blocks which contain transactions with either a To or From address the same as the given address.

How to run the API:

There is a swagger UI installed. Once the API is run via Visual Studio, the swagger UI page should load up.

Should this not work, the Swagger API is running on https://localhost:44334/index.html

Should you want to use Postman or your web browser, you can execute a query using the address below,

* https://localhost:44334/api/eth/search?address={address}&blockNumber={blockNumber}
where - address = search address
      - blockNumber = block number

Features of the API:

* Global Exception Handling via middleware
* Automapping of raw objects to dto's
* Extensibility - Adding the same operation for another blockchain is easier with generics
* Dependency injection

Example response:
[
  {
    "blockNumber": "9148873",
    "gas": "0.00000000000000021",
    "value": "0.8",
    "blockHash": "0x6dbde4b224013c46537231c548bd6ff8e2a2c927c435993d351866d505c523f1",
    "fromAddress": "0xc55eddadeeb47fcde0b3b6f25bd47d745ba7e7fa",
    "toAddress": "0x59422595656a6b7c8917625607934d0e11fa0c40",
    "transactionHash": "0x1fd509bc8a1f26351400f4ca206dbe7b8ebb8dcf3925ddf7201e8764e1bd3ea3"
  },
  {
    "blockNumber": "9148873",
    "gas": "0.00000000000000021",
    "value": "0.174",
    "blockHash": "0x6dbde4b224013c46537231c548bd6ff8e2a2c927c435993d351866d505c523f1",
    "fromAddress": "0xc55eddadeeb47fcde0b3b6f25bd47d745ba7e7fa",
    "toAddress": "0x15776a03ef5fdf2a54a1b3a991c1641d0bfa39e7",
    "transactionHash": "0xfcbbca93ff416601e5be95838fcfa2c534c48027b10172c12bf069784a4ec634"
  }
]

