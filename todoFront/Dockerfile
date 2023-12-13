# Run locally: docker run -p XXXX:80 yyyyyyyyyy
# XXXX is the host port, yyyyyyyyyy is the name of built image

# Build an docker image: docker buildx build -t learn-docker-frontend .

# Use the official Node.js image as the base image
FROM node:14

# Set the working directory in the container
WORKDIR /app

# Copy package.json and package-lock.json to the working directory
COPY package*.json ./

# Install app dependencies
RUN npm install

# Copy the rest of the app source code to the working directory
COPY . .

# Build the Vue.js app
RUN npm run build

# Expose the port your Vue.js app will run on
EXPOSE 80

# Start the app
CMD ["npm", "run", "serve"]