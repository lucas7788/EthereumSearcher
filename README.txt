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



