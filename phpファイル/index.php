<!DOCTYPE html>
<html>
<head>
<meta charset='utf-8'>
<title>HTML内にPHPを記述する方法</title>
</head>
<body><h1>

<?php
print("example");
?>

<?php

//phpinfo();

print("DB Connect Test");

// データベースへの接続に必要な変数を指定
$host = '';
$username = '';
$passwd = '';
$dbname = '';
 
// データベースへ接続
$db = mysqli_connect($host, $username, $passwd, $dbname);
 
// 接続チェック
if ($db == false) {
	die('データベースの接続に失敗しました。');
	print("失敗");
}else{
 
  echo "データベースの接続に成功しました！ \n";
　print("成功");
}

// データベースの接続を閉じる
mysqli_close($db);
?>

</h1></body></html>
