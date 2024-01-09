
kubectl apply -f central-library-pod.yaml
kubectl apply -f central-library-service.yaml
kubectl apply -f city-library-bg-pod.yaml
kubectl apply -f city-library-bg-service.yaml
kubectl apply -f city-library-ni-pod.yaml
kubectl apply -f city-library-ni-service.yaml
kubectl apply -f city-library-ns-pod.yaml
kubectl apply -f city-library-ns-service.yaml
kubectl apply -f ingress.yaml
