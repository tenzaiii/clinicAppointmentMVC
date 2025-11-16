<?php
// Database configuration
$servername = "localhost"; // Usually localhost
$username = "your_db_username";
$password = "your_db_password";
$dbname = "your_database_name";

try {
    // Create PDO connection
    $pdo = new PDO("mysql:host=$servername;dbname=$dbname", $username, $password);
    $pdo->setAttribute(PDO::ATTR_ERRMODE, PDO::ERRMODE_EXCEPTION);

    // Check if form is submitted
    if ($_SERVER["REQUEST_METHOD"] == "POST") {
        $email = $_POST['email'];
        $input_password = $_POST['password'];

        // Prepare and execute query to fetch user
        $stmt = $pdo->prepare("SELECT id, email, password FROM users WHERE email = :email");
        $stmt->bindParam(':email', $email);
        $stmt->execute();

        // Fetch user data
        $user = $stmt->fetch(PDO::FETCH_ASSOC);

        if ($user && password_verify($input_password, $user['password'])) {
            // Password is correct, start session
            session_start();
            $_SESSION['user_id'] = $user['id'];
            $_SESSION['email'] = $user['email'];
            
            // Redirect to dashboard or home page
            header("Location: dashboard.php");
            exit();
        } else {
            // Invalid credentials
            $error = "Invalid email or password";
            header("Location: login.html?error=" . urlencode($error));
            exit();
        }
    }
} catch(PDOException $e) {
    die("Connection failed: " . $e->getMessage());
}
?>