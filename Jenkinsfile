def run(String service, String dockerImage, String root, String lang, String envDeploy) {
    stage('Build Template') {
        echo "Building project with Docker Image: ${dockerImage} and Template: ${root}/${lang}, ENV: ${envDeploy}"
        sh """
            cd ${root}/${lang}/${envDeploy};
            sed -i 's|_SERVICE_NAME_|${service}|g' *;
            sed -i 's|_IMAGE_|${dockerImage}|g' *;

        """
        
    }
    stage('Deploy') {

        echo "Deploying K8s..."
        sh """
            export KUBECONFIG=/root/devops/k8s-config/admin.config;
            kubectl get nodes;

            kubectl apply -n ${envDeploy} -f ${root}/secret/docker-hub-secret.yaml

            cd ${root}/${lang}/${envDeploy};
            kubectl apply -n ${envDeploy} -f 03.deployment.yaml;
            kubectl get pods -n ${envDeploy};
        """
    }
}
return this