<script>
	import Continue from '../Continue.svelte';
	import { battleBgmExample } from '../Examples';
	import GameNotice from '../GameNotice.svelte';
	import Requirements from '../Requirements.svelte';

	$: example = $battleBgmExample;
</script>

<h1>Custom Battle BGM</h1>
<p>
	In the previous guide, you set all normal battles to use random BGM. But this also had the
	unintended effect of removing the music used during advantage battles.
</p>
<p>
	This guide will go over how you can add it back, customize the victory screen music, and even add
	disadvantage music.
</p>
<Requirements />
<h2>Current Music Script</h2>
<pre><code>{example.currentCode.join('\n')}</code></pre>
<h2>Battle Context</h2>
<p>
	A battle's context is how the player entered the battle. The three types are: <b>normal</b>, with
	an
	<b>advantage</b>, or at a <b>disadvantage</b>.
</p>
<p>
	There are two ways to set music depending on the battle's context, the first we'll be using is: <code
		>battle_bgm(normal, advantage, disadvantage)</code
	>.
</p>
<p>Where you see each battle context, you'll slot in the music you want played for that context.</p>
<h2>New Music Script</h2>
<pre><code>{example.newCode.join('\n')}</code></pre>
<p>
	Changes: a new constant with another 10 random songs was added and music was set to use <code
		>battle_bgm</code
	>. Let's break down the latter.
</p>
<h2>Battle BGM</h2>
<pre><code>{example.newCode[4]}</code></pre>
<pre><code>  music = battle_bgm(normal, advantage, disadvantage)</code></pre>
<p>Next to each other, hopefully it's clear how it works.</p>
<ul>
	<li>When the battle context is <b>normal</b>, it'll use <em>myRandomBgm</em>.</li>
	<li>When the battle context is <b>advantage</b>, it'll use <em>myRandomBgm2</em>.</li>
	<li>
		When the battle context is <b>disadvantage</b>, it'll play <em>{example.song}</em>.
	</li>
</ul>
<blockquote>
	<code>{example.songFunc}</code> is a new, but simple, feature. It lets you use in-game songs by name
	instead of BGM ID. Like collections, wrap the song's name in " " double quotes.
</blockquote>
<h2>So Far</h2>
<p>
	Now, normal battles will play 10 random songs during normal context, another 10 random songs
	during advantages, and a song during disadvantages.
</p>
<p>But what about Victory music (asked no one)?</p>
<h2>Victory Music</h2>
<p>
	While <code>battle_bgm</code> is great if you want to set music during normal/advantage, or all
	three, it doesn't let you change it for <em>just</em> advantage or <em>just</em> disadvantage.
</p>
<p>For Victory music, we'll use the second way to set music depending on context.</p>
<h2>The Second Way</h2>
<pre><code>{example.newCode2.join('\n')}</code></pre>
<p>Only one new line, and it reads pretty easy.</p>
<pre><code>{example.newCode2[5]}</code></pre>
<p>
	You specify you want to change the victory music, during advantage, and to play the song <em
		>{example.victorySong}</em
	>.
</p>
<blockquote>
	If you wanted to do the same for battle music, you would use <code
		>{example.newCode2[5].replace('victory_', '')}</code
	>.
</blockquote>
<h2>Finished</h2>
<GameNotice />
<p>Edit your script, save, add music, and test.</p>
<Continue />
