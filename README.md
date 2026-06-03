# 1131503_簡易版電子琴

## 專案簡介

本專案是一個使用 **C# Windows Forms** 製作的簡易電子琴程式。  
使用者可以透過點擊畫面上的 8 個按鈕，播放不同音階的聲音，模擬基本電子琴的操作方式。

本程式使用 Windows 系統提供的 `Beep()` 函式播放聲音，並加入視窗縮放功能，讓按鈕可以隨著視窗大小改變位置與大小，使介面更加彈性。

---

## 開發環境

| 項目 | 內容 |
|---|---|
| 開發工具 | Visual Studio |
| 程式語言 | C# |
| 專案類型 | Windows Forms App |
| 執行平台 | Windows |

---

## 功能介紹

### 1. 播放音階

程式提供 8 個按鈕，每個按鈕對應不同的聲音頻率。

| 按鈕 | 頻率 |
|---|---|
| btn1 | 523 Hz |
| btn2 | 587 Hz |
| btn3 | 659 Hz |
| btn4 | 698 Hz |
| btn5 | 784 Hz |
| btn6 | 880 Hz |
| btn7 | 988 Hz |
| btn8 | 1046 Hz |

當使用者點擊按鈕時，程式會播放對應頻率的聲音，播放時間為 300 毫秒。

---

### 2. 共用按鈕事件

本程式讓 `btn1` 到 `btn8` 共用同一個 Click 事件處理函式，避免每個按鈕都重複撰寫相同的程式碼。

```csharp
private void btn1_Click(object sender, EventArgs e)
{
    Button btn = sender as Button;
    btn.Enabled = false;
    Beep(freq[btn.TabIndex], 300);
    btn.Enabled = true;


