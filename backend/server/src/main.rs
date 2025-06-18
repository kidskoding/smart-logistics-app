use axum::{routing::get, Router};
use server::handlers::get_tracking_info::get_tracking_info;
use sqlx::PgPool;
use tokio::net::TcpListener;

#[tokio::main]
async fn main() -> sqlx::Result<()> {
    let port = 8000;
    let pool: PgPool = db::connection::connect().await?;
    let app = Router::new()
        .route("/", get(|| async { "hello smart-logistics-app server! (this is a test endpoint)" }))
        .route("/tracking/{tracking_id}", get(get_tracking_info))
        .with_state(pool);
    let listener = TcpListener::bind(format!("0.0.0.0:{port}"))
        .await?;

    println!("server is listening on port {port}");

    axum::serve(listener, app)
        .await?;

    Ok(())
}
