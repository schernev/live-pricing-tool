# Stage 1: set the image
FROM node:18 AS build

# Set the working directory for cloning the repository
WORKDIR /src

# Install Git
RUN apt-get update && apt-get install -y git

# Clone git repository
ARG REPO_URL=https://github.com/schernev/live-pricing-tool.git
RUN git clone $REPO_URL .

# Verify the directory structure
RUN ls -la /src/PricingToolClient && echo "Directory structure listed above"

# Install dependencies
WORKDIR /src/PricingToolClient
RUN npm install

# Build the application
RUN npm run build

# Stage 2: Serve the application with nginx
FROM nginx:alpine

# Copy the built application from the previous stage
COPY --from=build src/PricingToolClient/dist /usr/share/nginx/html
# Copy the nginx configuration file
COPY --from=build src/PricingToolClient/nginx.conf /etc/nginx/nginx.conf

# Expose port 80
EXPOSE 80

# Start nginx
CMD ["nginx", "-g", "daemon off;"]