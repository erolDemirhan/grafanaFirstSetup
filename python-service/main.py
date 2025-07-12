from fastapi import FastAPI
from prometheus_fastapi_instrumentator import Instrumentator

app = FastAPI()

# Prometheus ile ölçüm başlat
instrumentator = Instrumentator()
instrumentator.instrument(app).expose(app)

@app.get("/")
def read_root():
    return {"message": "Hello from Python microservice"}