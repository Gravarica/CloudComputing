
#!/bin/bash

# Delete Ingress
kubectl delete -f ingress.yaml

# Delete Services
kubectl delete -f central-library-service.yaml
kubectl delete -f city-library-bg-service.yaml
kubectl delete -f city-library-ni-service.yaml
kubectl delete -f city-library-ns-service.yaml

# Delete Pods
kubectl delete -f central-library-pod.yaml
kubectl delete -f city-library-bg-pod.yaml
kubectl delete -f city-library-ni-pod.yaml
kubectl delete -f city-library-ns-pod.yaml

# Delete Persistent Volume Claims
kubectl delete pvc --all

# Delete Persistent Volumes
kubectl delete pv --all
