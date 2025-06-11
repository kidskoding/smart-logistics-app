use axum::{routing::get, Router};
use backend::routes::tracking_route::tracking_route_handler;
use tokio::net::TcpListener;

#[tokio::main]
async fn main() -> Result<(), tokio::io::Error> {
    let port = 8000;
    let app = Router::new()
        .route("/", get(|| async { "Hello, smart logistics app server! (this is a test endpoint)"}))
        .route("/tracking", get(tracking_route_handler));
    let listener = TcpListener::bind(format!("localhost:{port}"))
        .await?;
    
    println!("Server starting on port {port}");

    axum::serve(listener, app)
        .await?;

    Ok(())
}